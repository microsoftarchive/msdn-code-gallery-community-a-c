using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementProgram
{
    class student
    {
        //physical descriptions of student
        private int age;
        private double height, weight;
        private string fName, lname, address, gender; // first name and last name respectively


        //Implementing methods
        public void setAge(int a) { age = a; }
        public int getAge() { return age; }

        public void setHeight(double h) { height = h; }
        public double getHeight() { return height; }

        public void setWeight(double w) { weight = w; }
        public double getWeight() { return weight; }

        public void setFName(string f) { fName = f; }
        public string getFName() { return fName; }

        public void setLName(string l) { lname = l; }
        public string getLName() { return lname; }

        public void setAddress(string p) { address = p; }
        public string getAddress() { return address; }

        public void setGender(string g) { gender = g; }
        public string getGender() { return gender; }

        //Constructor
       /* public student(string f, string l, int a, double h, double w, string g, string ad)
        {
            fName = f;
            lname = l;
            age = a;
            height = h;
            weight = w;
            gender = g;
            address = ad;

        }*/

        public void printStd()
        {
            
        }
    }
}
