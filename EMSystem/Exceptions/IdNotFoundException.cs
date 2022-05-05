using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Exceptions
{
    public class IdNotFoundException:Exception
    {
            public IdNotFoundException(string s) : base(s)
            {
            }
        
    }
}
