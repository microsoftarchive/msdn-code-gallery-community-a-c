using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionLibrary
{
    public static class StringExtensions
    {
        public static string EscapeApostrophe(this string pSender)
        {
            return pSender.Replace("'", "''");
        }
    }
}
