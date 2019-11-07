using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace AppHelpers
{
    public class CollectionHelpers
    {

        /// <summary>
        /// Case insensitive check if the collection contains the string.
        /// </summary>
        /// <param name="collection">The collection of objects, only strings are checked</param>
        /// <param name="match">String to match</param>
        /// <returns>true, if match contains in the collection</returns>
        public static bool CollectionContains(System.Collections.ICollection oCollection, string matchingstring)
        {
            foreach (object obj in oCollection)
            {
                string str = obj as string;
                if (str != null)
                {
                    if (string.Compare(str, matchingstring, true) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
