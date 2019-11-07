using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeyGen
{
    class Program
    {
        static void Main(string[] args)
        {
            HMACSHA256 hmac = new HMACSHA256();

            var key = hmac.Key;

            var rv = Convert.ToBase64String(key);

            Console.WriteLine(rv);
            Console.WriteLine("press enter to exit...");
            Console.ReadLine();
        }
    }
}
