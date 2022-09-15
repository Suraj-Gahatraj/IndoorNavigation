using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Domain.Dtos
{
    public  class MarkerImageGalleryDto
    {
        public string Id { get; set; }  
        public string Name { get; set; }    
        public string SiteId { get; set; }
        public Guid MarkerId { get; set; }
        public string ImageUrl { get; set; }
    }
}
