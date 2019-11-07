//-------------------------------------------
//author Zachery Walsh @ www.zacherywalsh.com
//-------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace slotMachine_console
{
    class Program
    {

        static void Main(string[] args)
        {
            //make random number generator
            Random randNumGen = new Random();

            //create credits for player to use
            int credits = 50;

            

            //welcome message
            Console.WriteLine("******************************************");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Welcome to Zach's Slot Machine!");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Press Spacebar to Roll the slot machine!");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("-------Credits Available: " + credits + "--------------");
            Console.WriteLine("******************************************");



            //call readkey for spacebar and store it in local variable
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            

            //embed while loop so you can play until yo run out of credits
            while(credits > 0)
            {
               
                //display number of credits
                Console.WriteLine("******************************************");
                Console.WriteLine("---$$----Credits Available: " + credits + "-----$$-----");
                Console.WriteLine("******************************************");

                    

                //roll slots
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    //spacebar pressed
                    //Console.WriteLine("Spacebar pressed");

                    //number of credits decreased by 1
                    credits--;

                    //declare slots
                    string slot1;
                    string slot2;
                    string slot3;

                    //record the next 3 numbers in the RandNumGen
                    int randNum1 = randNumGen.Next(10000, 20000);
                    int randNum2 = randNumGen.Next(30000, 40000);
                    int randNum3 = randNumGen.Next(50000, 60000);

                    //display the next 3 rand numbers
                    Console.WriteLine("First Random Number: " + randNum1);
                    Console.WriteLine("Second Random Number: " + randNum2);
                    Console.WriteLine("Third Random Number: " + randNum3);

                    //divide the 3 numbers by 8 with remainders (%)
                    int modR1 = randNum1 % 32;
                    int modR2 = randNum2 % 32;
                    int modR3 = randNum3 % 32;

                    //display remainder for user
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("1st Remainder Left over: " + modR1);
                    Console.WriteLine("2nd Remainder Left over: " + modR2);
                    Console.WriteLine("3rd Remainder Left over: " + modR3);
                    Console.WriteLine("------------------------------------------");

                    //creat an array table of strings so it can be referenced later for the random modulus lookups!
                    //here are the odds for the remainders
                    //0-7 GRAPE, 8-14 APPLE, 15-20 CHERRY, 21-25 BELL, 26-29 BAR, 30-31 Lucky 7

                    string[] slots = new string[32];

                    for (int i = 0; i < 8; i++)
                        slots[i] = "GRAPE";
                    for (int i = 8; i < 15; i++)
                        slots[i] = "APPLE";
                    for (int i = 15; i < 21; i++)
                        slots[i] = "WILD CHERRY";
                    for (int i = 21; i < 26; i++)
                        slots[i] = "BELL";
                    for (int i = 26; i < 30; i++)
                        slots[i] = "BAR";
                    for (int i = 30; i < 32; i++)
                        slots[i] = "Lucky 7";

                    slot1 = slots[modR1];
                    slot2 = slots[modR2];
                    slot3 = slots[modR3];


                    
                    //display slots for player to see
                    Console.WriteLine("Slot 1: " + slot1);
                    Console.WriteLine("Slot 2: " + slot2);
                    Console.WriteLine("Slot 3: " + slot3);

                    //check if you win
                    if ((slot1 == "GRAPE") && (slot2 == "GRAPE") && (slot3 == "GRAPE") )
                    {
                        //add credits
                        credits = credits + 3;

                        //display Win
                        Console.WriteLine("YOU WIN!! $$$$$$$$$ 3 CREDITS $$$$$$$$");
                    }

                    else if ((slot1 == "APPLE") && (slot2 == "APPLE") && (slot3 == "APPLE"))
                    {
                        //add credits
                        credits = credits + 6;

                        //display Win
                        Console.WriteLine("YOU WIN!! $$$$$$$$$ 6 CREDITS $$$$$$$$");
                    }

                    else if ((slot1 == "WILD CHERRY") && (slot2 == "WILD CHERRY") && (slot3 == "WILD CHERRY"))
                    {
                        //add credits
                        credits = credits + 10;

                        //display Win
                        Console.WriteLine("YOU WIN!! $$$$$$$$$ 10 CREDITS $$$$$$$$");
                    }

                    else if ((slot1 == "BELL") && (slot2 == "BELL") && (slot3 == "BELL"))
                    {
                        //add credits
                        credits = credits + 20;

                        //display Win
                        Console.WriteLine("YOU WIN!! $$$$$$$$$ 20 CREDITS $$$$$$$$$");
                    }

                    else if ((slot1 == "BAR") && (slot2 == "BAR") && (slot3 == "BAR"))
                    {
                        //add credits
                        credits = credits + 40;

                        //display Win
                        Console.WriteLine("YOU WIN!! $$$$$$$$ 40 CREDITS $$$$$$$$");
                    }

                    else if ((slot1 == "LUCKY 7") && (slot2 == "LUCKY 7") && (slot3 == "LUCKY 7"))
                    {
                        //add credits
                        credits = credits + 100;

                        //display Win
                        Console.WriteLine("JACKPOT!! $$$$$$$$ 100 CREDITS $$$$$$$$");
                    }

                    else
                    {
                        //display lose 
                        Console.WriteLine("BUST!! ##### NO CREDITS ######");
                    }


                    //store keyinfo in readkey
                    keyInfo = Console.ReadKey(true);

                }

                else
                {
                    Console.WriteLine("WRONG KEY!... Press Spacebar");
                    //store keyinfo in readkey
                    keyInfo = Console.ReadKey(true);
                }
            }

            
        }
    }
}
