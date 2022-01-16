using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Application.Features.Sites.Commands.CreateSite
{

    public static class ExtensionMethod
    {
        public static string ToMapConfigurationString(this List<SiteCoordinate> coordinates)
        {
            return JsonConvert.SerializeObject(coordinates);
        }


        public static List<SiteCoordinate>ToMapConfigurationObject(this string configuration)
        {
            var result= JsonConvert.DeserializeObject<List<SiteCoordinate>>(configuration); 
            return result;
        }
    }


    public  class CreateSiteVm
    {
        public string SiteName { get; set; }
        public string AdminId { get; set; }
        public List<SiteCoordinate> MapPointConfiguration { get; set; }
       
        public List<MapMarkerDto> MarkerPoints { get; set; }


    }

    public class MapMarkerDto
    {
        public string MarkerName { get; set; }
        public string BlobUrl { get; set; }
        public IFormFile Files { get; set; }
    }


    public class FileObject
    { 
        public IFormFile File { get; set; }
    }

    public class SiteCoordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
    }





}
