using IndoorNavigation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigation.Domain.Entities
{
   public  class Marker:AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public decimal X_Pos { get; set; }
        public decimal Y_Pos { get; set; }   
        public decimal Z_Pos { get; set; }
    }
}
