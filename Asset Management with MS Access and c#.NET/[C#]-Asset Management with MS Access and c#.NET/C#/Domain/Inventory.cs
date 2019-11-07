using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Inventory
    {
        string item;
        string model;
        string company;
        string type;
        string serial;
        string clientCom;
        string order;
        string dOrder;
        string dShip;
        string dMan;
        double price;

        //unit testing
        private string name;
        private double number;
        private double member;
        private bool test=false;
        public const string third_message = "Constraints_exceed";
        public const string fourth_message = "Contraints_less";
        /// <summary>
        /// /////////////
        /// </summary>
        public string Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Serial
        {
            get
            {
                return serial;
            }

            set
            {
                serial = value;
            }
        }

        public string ClientCom
        {
            get
            {
                return clientCom;
            }

            set
            {
                clientCom = value;
            }
        }

        public string Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
            }
        }

        public string DOrder
        {
            get
            {
                return dOrder;
            }

            set
            {
                dOrder = value;
            }
        }

        public string DShip
        {
            get
            {
                return dShip;
            }

            set
            {
                dShip = value;
            }
        }

        public string DMan
        {
            get
            {
                return dMan;
            }

            set
            {
                dMan = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public double Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public override string ToString()
        {
            return company+" "+item + " " + serial + " " + type + " "+dShip+"[DATE OF SHIPPING]";
        }

        //unit test
        public Inventory()
        {

        }
        public Inventory(string nam, double num)
        {
            name = nam;
            num = number;
        }

        public void first(double num1)
        {
            if(test)
            {
                throw new Exception("Test1");
            } 
            if (member > price)
            {
                throw new ArgumentOutOfRangeException("Test1_1");
            }
            if (member < 0)
            {
                throw new ArgumentOutOfRangeException("Test1_1");
            }
            price -= member;
        }
        //related to the first test
        public void first_hlp(double newNumber)
        {
            if (test)
            {
                throw new Exception("Test2");
            }
            if (member < 0)
            {
                throw new ArgumentOutOfRangeException("Test2_1");
            }
            price += member;
        }
        public void second (double num2)
        {
            double m = member - price;
            if(test)
            {
                throw new Exception("Test1");
            }
            if(m > price)
            {
                throw new ArgumentOutOfRangeException("Test3_1");
            }
            if(m < 0)
            {
                throw new ArgumentOutOfRangeException("Test3_2");
            }
        }
        public bool third (int num3,int num4)
        {
            if (num3 < num4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool fourth(int numberOfOrderDates,int numberOfShippingDates)
        {
            if (numberOfOrderDates < numberOfShippingDates )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool fifth (string companyName,double clientName)
        {
            if (companyName == " ")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void test_1()
        {
            test = true;
        }
        private void test_2()
        {
            test = false;
        }
        public static void some()
        {
            Inventory iv = new Inventory("Sometext", 11.99);
            iv.first(5.77);
            iv.second(11.22);
        }

    }
}



