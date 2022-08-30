using IndoorNavigation.Application.Contracts.Persistence;
using IndoorNavigation.Application.Features.Sites;
using IndoorNavigation.Application.Features.Sites.Commands.CreateSite;
using IndoorNavigation.Domain.Dtos;
using IndoorNavigation.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Persistence.Repositories.EntityRepositories
{

    public static class FileUtility
    {
        public static string GetSiteMapUploadPath(string siteId, string markerName, out string fileName)
        {
            var storagePath = Path.Combine(Environment.CurrentDirectory + "\\uploads\\SiteMapImageUploads\\" + siteId);
            fileName = siteId + "_" + markerName + "_" + DateTime.Now.Millisecond.ToString();
            return storagePath;
        }

        public static string GetSiteMarkerGalleryUploadPath(string siteId,string markerId, string markerName, out string fileName)
        {
            var storagePath = Path.Combine(Environment.CurrentDirectory + "\\uploads\\SiteMapMarkerUploads\\" + siteId+"\\"+markerId);
            fileName = siteId + "_" + markerId + "_" + DateTime.Now.Millisecond.ToString();
            return storagePath;
        }




        public static async Task<List<string>> ReadAsStringAsync(this IFormFile file)
        {
            var result=new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.Add(await reader.ReadLineAsync()); 
                    
            }
            return result;
        }


        public static string GetExtension(this string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return string.IsNullOrEmpty(extension) ? string.Empty : extension.Replace(".", string.Empty).ToLower();
        }

        public static string GetSiteMarkerUploadPath(string siteId, string markerName, out string fileName)
        {

            var storagePath = Path.Combine(Environment.CurrentDirectory + "\\uploads\\SiteMapMarkerUploads\\" + siteId);
            fileName = siteId + "_" + markerName + "_" + DateTime.Now.Millisecond.ToString();
            return storagePath;

        }
        public static async Task Upload(MemoryStream ms, string filePath)
        {

        }

        public static  async Task<string> Upload(IFormFile file, string filePath, string fileName)
        {

            var extension = file.FileName.GetExtension();
            var directoryNotExist = !Directory.Exists(filePath);
            if (directoryNotExist)
            {
                Directory.CreateDirectory(filePath);
            }

            filePath = Path.Combine(filePath, fileName + "_." + extension);
            using (var fileStream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;

        }


        public static string GetStaticDownloadLink(string url)
        {
            if (url == "") return "";
            var splittingUrl = url.Split(@"uploads\");
            var requiredUrl = splittingUrl[1].Replace(@"\", "/");
            var newFileLocation = @"https://api.bandbnavigation.com/" + "uploads/" + requiredUrl;
            return newFileLocation;
        }
    }





    public  class SiteRepository:ISiteRepository
    {
        private readonly IndoorNavigationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public SiteRepository(IndoorNavigationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager; 
        }

        public async Task<SiteViewDto> CreateSite( CreateSiteVm input,string userId)
        {
          

            var mapPointConfiguration = await input.MapPointConfigurationFile.ReadAsStringAsync();   
            var mapPointConfigurationString  = JsonConvert.SerializeObject(mapPointConfiguration);
            // extracting data from MapMarkerConfigFile     
            var mapMarkerFileData = new List<string>();
            using (var reader = new StreamReader(input.MapMarkerFile.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    mapMarkerFileData.Add(await reader.ReadLineAsync());
            }

            //3.8§2.58§90§1.43§16§164§555§328

            /*
             * 
             *  3.8 = lentght of site map in meter
                §2.58 = breadth of site in meter
                §90 = angle to scan marker
                §1.43 = marker width and height (square)
                §16 = x position of marker with respect to map image. 
                §164 = y position of marker in sitemap coordinate space
                §555 = (X dim)image dimension of site map
                §328 (y dim)image dimension of site map
             * */
            var mapMarkerData = mapMarkerFileData[0].Split("§");
            var newSite = new Site()
            {
                AdminId = Guid.Parse(userId),
                SiteName = input.SiteName,
                CreatedBy = userId,
                CreatedOn = DateTime.Now,
                LastModifiedBy = userId,
                MapPointConfiguration = mapPointConfigurationString,
                SiteMapLength = Convert.ToDouble(mapMarkerData[0]),
                SiteMapBreadth = Convert.ToDouble(mapMarkerData[1]),
                SiteMapImageHeight = Convert.ToDouble(mapMarkerData[7]),
                SiteMapImageWidth = Convert.ToDouble(mapMarkerData[6]),

            };

            _context.Sites.Add(newSite);

            await UploadAsync(input, newSite);

            var mapMarkerList=new List<MapMarker>();

            var newMapMarker = new MapMarker()
            {
                MarkerName="",
                MapMarkerBlobUrl = "",
                CreatedBy = userId,
                CreatedOn = DateTime.Now,
                LastModifiedBy = userId,
                MarkerHeight = Convert.ToDouble(mapMarkerData[3]),
                MarkerWidth = Convert.ToDouble(mapMarkerData[3]),
                MarkerScanAngle = Convert.ToDouble(mapMarkerData[2]),
                Marker_XPos = Convert.ToDouble(mapMarkerData[4]),
                Marker_YPos = Convert.ToDouble(mapMarkerData[5]),


            };
            mapMarkerList.Add(newMapMarker);     
            newSite.MapMarkers = mapMarkerList;
            await UploadMarkerAsync(input, newSite, newMapMarker);
            _context.SaveChanges();

            var viewModel = new SiteViewDto()
            {
                SiteId = newSite.Id,
                SiteName = newSite.SiteName,
                SiteMapUrl = newSite.SiteMapUrl
            };

            return viewModel;
        }


        public async Task UploadAsync(CreateSiteVm model, Site site)
        {
            var attachments = model.SiteMapImage;

            string fileName = String.Empty;
            var uploadPath = FileUtility.GetSiteMapUploadPath(site.Id.ToString(), model.SiteName, out fileName);
            var blobUrl = await FileUtility.Upload(model.SiteMapImage, uploadPath, fileName);
            site.SiteMapUrl = blobUrl;

        }

        public async Task UploadMarkerAsync(CreateSiteVm model, Site site, MapMarker mapMarker)
        {
            var attachments = model.SiteMarkerImage;

            string fileName = String.Empty;
            var uploadPath = FileUtility.GetSiteMarkerUploadPath(site.Id.ToString(), model.SiteName, out fileName);
            var blobUrl = await FileUtility.Upload(model.SiteMarkerImage, uploadPath, fileName);
            //site.SiteMapUrl = blobUrl;

            mapMarker.MapMarkerBlobUrl = blobUrl;
        }


        public async Task<List<SiteListVm>> GetAllAdminSite(string userId)

        {
            
            var siteTest = _context.Sites.Where(x => x.AdminId == Guid.Parse(userId)).ToList();

            var mapMarkerList = _context.MapMarkers.Where(x => siteTest.Select(x => x.Id).Contains(x.SiteId)).ToList();
            var siteList = _context.Sites.Where(x => x.AdminId == Guid.Parse(userId)).ToList().Select(x => new SiteListVm
            {
                SiteId = x.Id.ToString(),
                SiteName=x.SiteName,
                SiteMapUrl = FileUtility.GetStaticDownloadLink(x.SiteMapUrl),
                SiteMapWidth = x.SiteMapImageWidth,
                SiteMapHeight = x.SiteMapImageHeight,
                SiteMapLength = x.SiteMapLength,
                SiteMapBreadth = x.SiteMapBreadth,
               MapPoints = x.MapPointConfiguration.ToMapConfigurationObject().ToList(),
                Markers = mapMarkerList.Where(y=>y.SiteId==x.Id).Select(x => new MarkerInfo
                {
                    MarkerImageUrl = FileUtility.GetStaticDownloadLink(x.MapMarkerBlobUrl),
                    MarkerName = x.MarkerName,
                    PositionX=x.Marker_XPos,
                    PositionY=x.Marker_YPos,
                    MarkerDim=x.MarkerWidth,
                    MarkerScanAngle=x.MarkerScanAngle

                })

            }).ToList(); 

            return siteList;    
        }


        public async Task<bool> DeleteSiteAysnc(string id)
        {
            var siteId = Guid.Parse(id);
            //find the ite first

            var site = _context.Sites.Where(x => x.Id == siteId).FirstOrDefault();
            if (site == null) return false;

            else
            {
                _context.Sites.Remove(site);
                _context.SaveChanges();
                return true;
            }
        }


        public Task<Site> AddAsync(Site entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Site entity)
        {
            throw new NotImplementedException();
        }

        public Task<Site> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Site>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Site entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateSiteMapMarker(SiteMapMarkerVm input)
        {
            try
            {
                string siteId = input.SiteId;
                string markerId = input.MarkerId;
                string name = input.Name;

                var mapmakersList = new List<SiteMarkerImage>();
                foreach (var image in input.ImageFiles)
                {
                    var attachments = image;
                    string fileName = "";
                    var uploadPath = FileUtility.GetSiteMarkerGalleryUploadPath(siteId, markerId, name, out fileName);
                    var markerImageUrl = await FileUtility.Upload(image, uploadPath, fileName);
                    mapmakersList.Add(new SiteMarkerImage()
                    {
                        Name = name,
                        SiteId = siteId,
                        MapMarkerId = markerId,
                        ImageUrl = markerImageUrl
                    });

                }

                _context.siteMarkerImages.AddRange(mapmakersList);
                _context.SaveChanges();

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
            
            // start uploading the file to the server
        }

        public async Task<List<MarkerImageGalleryDto>> GetMarkerImageGallery(string siteId, string markerId)
        {
            try
            {
                var query = _context.siteMarkerImages.Where(x => x.SiteId == siteId && x.MapMarkerId == markerId).Select(x => new MarkerImageGalleryDto
                {
                    Name = x.Name,
                    SiteId = x.SiteId,
                    MarkerId = x.MapMarkerId,
                    ImageUrl = FileUtility.GetStaticDownloadLink(x.ImageUrl),
                }).ToList();
                return query;
            }

            catch { 
                    
            
            }
       
            throw new NotImplementedException();
        }
    }
}
