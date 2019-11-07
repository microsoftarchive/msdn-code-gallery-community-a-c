using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bruteforce
{
    class Program
    {
        //define likely password characters
        static char[] Match =  {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p',
                                'q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','C','L','M','N','O','P',
                                'Q','R','S','T','U','V','X','Y','Z','!','?',' ','*','-','+'};
        //your password
        static string FindPassword;
        static int Combi;
        static string space;        

        static void Main(string[] args)
        {
            space = " ";
            int Count;
            Console.WriteLine("Welcome to BRUTE FORCE with RA-BI");
            Console.WriteLine(space);
            Console.WriteLine("Enter your Password");
            //initialize your password
            FindPassword = (Console.ReadLine());

            DateTime today = DateTime.Now;
            today.ToString("yyyy-MM-dd_HH:mm:ss");
            Console.WriteLine(space);
            Console.WriteLine("START:\t{0}", today);
            for (Count = 0; Count <= 15; Count++)
            {
                Recurse(Count, 0, "");
            }
        }

        static void Recurse(int Lenght, int Position, string BaseString)
        {
            int Count = 0;

            for (Count = 0; Count < Match.Length ; Count++)
            {
                Combi++;
                if (Position < Lenght - 1)
                {
                    Recurse(Lenght, Position + 1, BaseString + Match[Count]);
                }
                if (BaseString + Match[Count] == FindPassword)
                {
                    DateTime today = DateTime.Now;
                    today.ToString("yyyy-MM-dd_HH:mm:ss");
                    Console.WriteLine(space);
                    Console.WriteLine("END:\t{0}\nCombi:\t{1}", today, Combi);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }
    }
}
