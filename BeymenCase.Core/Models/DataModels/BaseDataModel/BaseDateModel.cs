using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeymenCase.Core.Models
{
    public class BaseDateModel : BaseEntityModel
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}