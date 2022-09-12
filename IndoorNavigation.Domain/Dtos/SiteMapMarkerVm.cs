using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Domain.Dtos
{
    public  class SiteMapMarkerVm
    {
       
        public string SiteId { get; set; }
        public string MarkerId { get; set; }

        public List<MarkerImageGallery> ImageGalleries { get; set; }

       
       
    }

    public class MarkerImageGallery
    {
        public string Name { get; set; }    
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public IFormFile Image { get; set; }
    }



}
