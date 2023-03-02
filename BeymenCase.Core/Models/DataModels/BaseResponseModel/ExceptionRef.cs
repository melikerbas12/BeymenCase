using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeymenCase.Core.Models
{
    public class ExceptionRef
    {
        public bool IsSuccess { get; set; }
        public ResponseCode ResponseCode { get; set; }
        public string Message { get; set; }
    }
}