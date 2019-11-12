using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDetailsServiceLayer.Models
{
    public class Student
    {
        public string name { get; set; }
        public int id { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
    }
}