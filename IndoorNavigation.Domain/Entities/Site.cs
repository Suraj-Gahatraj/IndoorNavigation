using IndoorNavigation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Domain.Entities
{
    public class Site:AuditableEntity
    {
        public Guid Id { get; set; }
        public string SiteName { get; set; }
        public Guid AdminId { get; set; }
        public double SiteMapImageWidth { get; set; }
        public double SiteMapImageHeight { get; set; }
        public double SiteMapLength { get; set; }
        public double SiteMapBreadth { get; set; }
        public string SiteMapUrl { get; set; }
        public string MapPointConfiguration { get; set; }
        public virtual ICollection<MapMarker> MapMarkers { get; set; }
        public virtual ICollection<Marker> Markers { get; set; }
    }

}
