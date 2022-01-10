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
        public string BlobUrl { get; set; }
        public virtual Site Site { get; set; }
    }
}
