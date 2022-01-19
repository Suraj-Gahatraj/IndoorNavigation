using IndoorNavigation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Domain.Entities
{
    public  class MapMarker:AuditableEntity
    {
        public Guid Id { get; set; }
        public string MarkerName { get; set; }
        public Guid SiteId { get; set; }
        public double MarkerScanAngle { get; set; }
        public double MarkerWidth { get; set; }
        public double MarkerHeight { get; set; }
        public double Marker_XPos { get; set; }
        public double Marker_YPos { get; set; }
        public string MapMarkerBlobUrl { get; set; }
        public virtual Site Site { get; set; }
    }
}
