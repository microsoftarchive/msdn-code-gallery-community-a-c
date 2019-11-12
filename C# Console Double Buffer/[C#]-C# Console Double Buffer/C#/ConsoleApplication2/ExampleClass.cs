using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleBuffer
{
    class ExampleClass
    {
        static int width = 80;
        static int height = 30;
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Double buffer example";
            System.Console.SetBufferSize(width, height);
            System.Console.SetWindowSize(width, height);
            Console.Clear();
            buffer myBuf = new buffer(width, height, width, height);
            myBuf.Draw("H", 0, 0, 2); //The last number is the attribute (aka color for forground and background. 1 is black, 15 is white. 16 is blue background with black forground.
            myBuf.Draw("e", 1, 1, 3);
            myBuf.Draw("l", 2, 2, 4);
            myBuf.Draw("l", 3, 3, 5);
            myBuf.Draw("o", 4, 4, 6);
            myBuf.Draw("w", 5, 5, 7);
            myBuf.Draw(" ", 6, 6, 8);
            myBuf.Draw("W", 7, 7, 9);
            myBuf.Draw("o", 8, 8, 10);
            myBuf.Draw("r", 9, 9, 11);
            myBuf.Draw("l", 10, 10, 12);
            myBuf.Draw("d", 11, 11, 13);
            myBuf.Draw("How are you? Press enter when ready.", 0, 12, 15);
            myBuf.Print();
            Console.ReadLine();
            myBuf.Draw("Did you see a flicker? Press Enter when ready.", 0, 13, 18);
            myBuf.Print();
            Console.ReadLine();
            myBuf.Draw("No? That is because you are using a double buffer!", 0, 14, 29);
            myBuf.Print();
            Console.ReadLine();
        }
    }
}
