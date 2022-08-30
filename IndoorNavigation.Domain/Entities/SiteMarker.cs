using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Domain.Entities
{
    public  class SiteMarker
    {
        public Guid Id { get; set; }    
        public string MarkerName { get; set; }
        public Guid SiteId { get; set; }
        public Site Site { get; set; }
    }
}
