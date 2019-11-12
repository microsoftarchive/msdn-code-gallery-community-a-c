using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSequentialSearch
{
    class Program
    {
        public static int linearSearch(int[] list, int item)
        {
            int value = -1;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == item)
                {
                    value = i;
                    break;
                }
            }
            return value;
        }
        static void Main(string[] args)
        {
            int[] list = {1 , 20, 3436,5 , 614, 71, 9, 3, 42, 114, 10, 42 ,33, 87, 124087};
            Console.WriteLine("Raw string:");
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine("\r\nPlease enter the number to be queried:");

            int item = System.Convert.ToInt32(Console.ReadLine());
            int index = linearSearch(list, item);
            if (index >= 0)
            {
                Console.WriteLine("To find the index of position in " + index);
            }
            else
            {
                Console.WriteLine("Can't find it!");
            }

            Console.ReadLine();
        }
    }
}
