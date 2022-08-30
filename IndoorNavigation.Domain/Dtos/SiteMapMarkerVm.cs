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

        public string Name { get; set; }
        public IFormFileCollection ImageFiles { get; set; }
    }
}
