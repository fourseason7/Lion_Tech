using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSolution
{
    public static class eMESHelper
    {
          public static string Right(this string value, int length)
            {
	        return value.Substring(value.Length - length);
            }
    }
}
