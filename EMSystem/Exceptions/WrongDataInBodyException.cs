using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Exceptions
{
    public class WrongDataInBodyException:Exception
    {
        public WrongDataInBodyException(string s) : base(s)
        {
        }
    }
}
