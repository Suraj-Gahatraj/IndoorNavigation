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


        public static List<string>ToMapConfigurationObject(this string configuration)
        {
            var result= JsonConvert.DeserializeObject<List<string>>(configuration); 
            return result;
        }
    }


    public  class CreateSiteVm
    {
        public string SiteName { get; set; }
        public IFormFile SiteMapImage { get; set; }
        public IFormFile MapPointConfigurationFile { get; set; }
        public IFormFile MapMarkerFile { get; set; }

    }

    public class MapMarkerDto
    {
        public string MarkerName { get; set; }
        public double SiteMapLength { get; set; }
        public double SiteMapBreadth { get; set; }
        public double MarkerScanAngle { get; set; }
        public double MarkerWidth { get; set; }
        public double MarkerHeight { get; set; }
        public double Marker_XPos { get; set; }
        public double Marker_YPos { get; set; }
        public double SiteMap_XDimension { get; set; }
        public double SiteMap_YDimension { get; set; }
    }


    public class SiteCoordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
    }





}
