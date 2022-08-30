using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Domain.Entities
{
    public  class SiteMarkerImage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SiteId { get; set; }
        
        public string ImageUrl { get; set; }
        public string MapMarkerId { get; set; } //sitemarker Id  is MapMarkerId
    }

    //abstract concept map is like a site 
}
