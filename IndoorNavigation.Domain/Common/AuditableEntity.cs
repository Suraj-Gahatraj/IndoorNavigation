using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Domain.Common
{
    public  class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } 
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
