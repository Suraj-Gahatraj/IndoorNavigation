using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Domain.Dtos
{
    public  class SiteViewDto
    {
        public Guid SiteId { get; set; }  
        public string SiteName { get; set; }
        public string SiteMapUrl { get; set; }
    }
}
