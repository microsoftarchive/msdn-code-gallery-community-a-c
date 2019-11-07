using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeGen.Web.Utility
{
    public static class Conversion
    {
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, @"[^0-9a-zA-Z]", ""); ;
        }
    }
}
