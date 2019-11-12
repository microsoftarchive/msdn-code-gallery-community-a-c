using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    using System;

    namespace StudentApiApplication.Models
    {
        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public string Course { get; set; }
        }
    }
}