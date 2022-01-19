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
        public string SiteMapUrl { get; set; }
        public double SiteMapWidth { get; set; }
        public double SiteMapHeight { get; set; }
        public double SiteMapLength { get; set; }
        public double SiteMapBreadth { get; set; }
        public IEnumerable<string> MapPoints { get; set; }

        public IEnumerable<MarkerInfo> Markers { get; set; }

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
