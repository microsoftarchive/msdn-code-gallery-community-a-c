using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DAL
{
    public class Instructor : Person
    {
        public Instructor()
        {
            Courses = new List<Course>();
        }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Hire date is required.")]
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public OfficeAssignment OfficeAssignment { get; set; }
    }
}