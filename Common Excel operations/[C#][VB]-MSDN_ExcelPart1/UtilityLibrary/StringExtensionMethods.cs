using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary
{
    public static class StringExtensions
    {
        public static bool ContainsSpecial(this string pSource, string pContainsValue, StringComparison comp)
        {
            return pSource?.IndexOf(pContainsValue, comp) >= 0;
        }
    }
}
