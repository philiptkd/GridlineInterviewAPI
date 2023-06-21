using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridlineInterviewAPI.Core
{
    public class Utility
    {
        public static string Reverse(string str)
        {
            return new string(str.Reverse().ToArray());
        }
    }
}
