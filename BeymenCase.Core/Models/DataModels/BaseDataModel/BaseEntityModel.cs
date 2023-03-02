using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeymenCase.Core.Models
{
    public abstract class BaseEntityModel
    {
        public DateTime CreatedDate { get; set; }  
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }  
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}