using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeymenCase.Core.Models
{
    public class BoolRef
    {
        public bool Result { get; set; }
        public BoolRef(bool value)
        {
            this.Result = value;
        }

        public static implicit operator BoolRef(bool val)
        {
            return new BoolRef(val);
        }

        public static bool operator true(BoolRef val) => val.Result;
        public static bool operator false(BoolRef val) => !val.Result;

    }
} 