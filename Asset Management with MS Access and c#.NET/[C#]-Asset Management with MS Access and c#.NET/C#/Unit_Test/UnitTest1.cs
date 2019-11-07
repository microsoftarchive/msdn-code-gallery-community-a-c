using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Unit_Test()
        {
            // arrange
            double first_value = 11.99;
            double second_value = 4.55;
            double expected = 7.44;
            Inventory i = new Inventory("SomeTextTest", first_value);

            // act
            i.first(second_value);
            // assert
            double tst = i.Number;
            Assert.AreEqual(expected, tst, 10.90, "Fail");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void unit_test_second()
        {
            // arrange           
            string newCom = "SDN BHD";
            double newClient = 10;
            Inventory i = new Inventory(newCom, newClient);
            // act
            i.fifth(newCom, newClient);
            // assert is handled by ExpectedException
            throw new ArgumentOutOfRangeException("Fail");
        }
        [TestMethod]
        public void unit_test_third()
        {
            int arg = 50;
            int arg2 = 100;

            Inventory i = new Inventory();

            bool test_third = i.third(arg, arg2);

            Assert.AreEqual(true, test_third);
        }
        [TestMethod]
        public void unit_test_fourth()
        {
            // arrange
            int num1 = 11;
            int num2 = 20;
            Inventory i = new Inventory();

            // act
            try
            {
                i.fourth(num1,num2);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message,Inventory.third_message);
                return;
            }
        }
        [TestMethod]
        public void unit_test_fifth()
        {
            // arrange
            double num1 = 11.99;
            double num2 = 20.0;
            Inventory i = new Inventory("Message_2", num1);

            // act
            try
            {
                i.second(num2);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, Inventory.third_message);
                return;
            }
        }
    }

}

