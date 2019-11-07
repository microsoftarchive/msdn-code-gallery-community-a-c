using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Arithmetic
{
    class Program
    {
        //validate the input to a double data type
        static bool InputValidator(string input)
        {
            string pattern = "[^0-9][.]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //define your version of arithmetic methods
        static void add(double n1, double n2)
        {
            Console.WriteLine("The Result is:{0}\n",n1 + n2);
        }
        static void sub(double n1,double n2)
        {
            Console.WriteLine("The Result is:{0)\n",n1 - n2);
        }
        static void mult(double n1, double n2)
        {
            Console.WriteLine("The Result is:{0}\n", n1 * n2);
        }
        static void div(double n1, double n2)
        {
            if(n2==0)
            {
                Console.WriteLine("ALERT: Division by zero is invalid!");
                
            }
            else
            {
                Console.WriteLine("The Result is:{0}\n", n1 / n2);
            }
        }
        static void Main(string[] args)
        {
            //define main commands you want
            string cmd = String.Empty;
            do
            {
                Console.WriteLine("This is an arithmetic calculator Command Prompt");
                Console.WriteLine("Type help to get the list of commands available");
                Console.WriteLine("To exit at any time type exit command");
                //default command symbol
                Console.Write(":>");
                //make input as case insensitive
                cmd = Console.ReadLine().ToString().ToLower();
                switch(cmd)
                {
                    //help command case here
                case "help": 
                StringBuilder sb = new StringBuilder();
                sb.Append("start    Starts Calculator\n");
                        sb.Append("exit     Exits Calculator\n");
                        sb.Append("cls      Clears the Screen\n");
                        Console.WriteLine(sb.ToString());
                break;
                        //exit command case here
                    case "exit":
                        break;
                        //start command case here
                    case "start":
                        {
                            //take two inputs for the arithmetic operations
                            Console.WriteLine("Enter two numbers:");
                            string n1 = Console.ReadLine();
                            string n2 = Console.ReadLine();
                            //define two double variables for the inputs
                            double num1=0.0, num2=0.0;
                            //Filter the input for double data type here
                            try
                            {
                                if ((InputValidator(n1) == true) && (InputValidator(n2) == true))
                                {
                                    Console.WriteLine("Enter only numbers here!");
                                }
                                else
                                {
                                    //covert the input into a double data type
                                    num1 = double.Parse(n1);
                                    num2 = double.Parse(n2);
                                    StringBuilder sb1 = new StringBuilder();
                                    //arithmetic commands
                                    sb1.Append("add:Addition\n");
                                    sb1.Append("sub:Subtraction\n");
                                    sb1.Append("mult:Multiplication\n");
                                    sb1.Append("div:Division");
                                    Console.WriteLine("Type your commands here:\n" + sb1.ToString());
                                    Console.Write(">:");
                                    string choice = Console.ReadLine().ToString().ToLower();
                                    switch (choice)
                                    {
                                        case "add":
                                            add(num1, num2);
                                            break;
                                        case "sub":
                                            sub(num1, num2);
                                            break;
                                        case "mult":
                                            mult(num1, num2);
                                            break;
                                        case "div":
                                            div(num1, num2);
                                            break;
                                        default:
                                            //default command error message
                                            Console.WriteLine("Bad Command");
                                            break;
                                    }
                                }

                            }
                            catch
                            {
                                //arithmetic operation failure message
                                Console.WriteLine("ALERT: Something isn't right!");
                            }
                            
                            break;
                        }
                        //clear screen command case
                    case "cls":
                        Console.Clear();
                        break;
                    default:
                        //default wrong command message
                        Console.WriteLine("Bad Command");
                        break;   

            }

            }
           //run the screen till exit command typed
            while (cmd.ToLower()!="exit");
        }
    }
}
