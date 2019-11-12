using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DAL
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int CourseID { get; set; }

        public int PersonID { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true, NullDisplayText = "No grade")]
        public decimal? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}