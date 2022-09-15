using IndoorNavigation.Application.Features.Sites.Commands.CreateSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Application.Features.Sites
{
    public class SiteListVm
    {
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteMapUrl { get; set; }
        public double SiteMapWidth { get; set; }
        public double SiteMapHeight { get; set; }
        public double SiteMapLength { get; set; }
        public double SiteMapBreadth { get; set; }
        public IEnumerable<string> MapPoints { get; set; }

        public IEnumerable<MarkerInfo> Markers { get; set; }
        public IEnumerable<MarkerGalleryDto> SiteMarkers { get; set; }

    }

    public class MarkerGalleryDto
    {
        public string MarkerId { get; set; }
        public string MarkerName { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }  
        public decimal Z { get; set; }  
        public IEnumerable<ImageDetail> Images { get; set; }
    }


    public class ImageDetail
    {
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }    
    }

    public class MarkerInfo
    {
        public string MarkerImageUrl { get; set; }

        public string MarkerName { get; set; }  
        public double PositionX { get; set; }
        public double PositionY { get; set; }

        public double MarkerDim { get; set; }
        public double MarkerScanAngle { get; set; }
    }
}
