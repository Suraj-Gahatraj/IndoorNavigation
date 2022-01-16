using IndoorNavigation.Application.Contracts.Persistence;
using IndoorNavigation.Application.Features.Sites;
using IndoorNavigation.Application.Features.Sites.Commands.CreateSite;
using IndoorNavigation.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        public static string GetSiteMarkerUploadPath(string siteId, string markerName, out string fileName)
        {
            var storagePath = Path.Combine(Environment.CurrentDirectory + "\\uploads\\SiteMarkerImageUploads\\" + siteId);
            fileName = siteId + "_" + markerName + "_" + DateTime.Now.Millisecond.ToString();
            return storagePath;
        }


        public static string GetExtension(this string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return string.IsNullOrEmpty(extension) ? string.Empty : extension.Replace(".", string.Empty).ToLower();
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

        public async Task CreateSite( CreateSiteVm input)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var mapPointConfiguration = input.MapPointConfiguration.ToMapConfigurationString();
            var newSite = new Site()
            {
                AdminId = Guid.Parse(input.AdminId),
                SiteName = input.SiteName,
                CreatedBy = input.AdminId,
                CreatedOn = DateTime.Now,
                LastModifiedBy = input.AdminId,
                MapPointConfiguration = mapPointConfiguration
            };

            _context.Sites.Add(newSite);

            await UploadAsync(input, newSite);

            var mapMarkerList=new List<MapMarker>();
             
            foreach(var data in input.MarkerPoints)
            {
                mapMarkerList.Add(new MapMarker() {
                    BlobUrl = data.BlobUrl, 
                    MarkerName = data.MarkerName,
                    CreatedBy = input.AdminId,
                    CreatedOn = DateTime.Now,
                    LastModifiedBy = input.AdminId,
                });
            }
            
            newSite.MapMarkers = mapMarkerList;       
            _context.SaveChanges();

        }


        public async Task UploadAsync(CreateSiteVm model, Site site)
        {
            var attachments = model.MarkerPoints;

            foreach (var attachment in attachments)
            {
                // var fileName = String.Empty;
                string fileName = String.Empty;
                var uploadPath = FileUtility.GetSiteMarkerUploadPath(site.Id.ToString(), attachment.MarkerName, out fileName);
                var blobUrl=await FileUtility.Upload(attachment.Files, uploadPath, fileName);
                attachment.BlobUrl = blobUrl; 
                
            }

        }


        public async Task<List<SiteListVm>> GetAllAdminSite(string userId)

        {
            //var siteMapData=

            var siteTest = _context.Sites.Where(x => x.AdminId == Guid.Parse(userId)).ToList();

            var mapMarkerList = _context.MapMarkers.Where(x => siteTest.Select(x => x.Id).Contains(x.SiteId)).ToList();
            var siteList = _context.Sites.Where(x => x.AdminId == Guid.Parse(userId)).ToList().Select(x => new SiteListVm
            {
                SiteId = x.Id.ToString(),
                SiteMapUrl = "test.bmp",
                SiteMapWidth = 20.5,
                SiteMapHeight = 23.5,
                SiteMapLength = 45.6,
                SiteMapBreadth = 34.5,
               MapPoints = x.MapPointConfiguration.ToMapConfigurationObject().ToList(),
                Markers = mapMarkerList.Where(y=>y.SiteId==x.Id).Select(x => new MarkerInfo
                {
                    MarkerImageUrl = x.BlobUrl,
                    MarkerName = x.MarkerName,

                })

            }).ToList(); 

            return siteList;    
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




       





    }
}
