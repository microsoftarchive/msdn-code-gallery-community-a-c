using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DAL
{
    public class EnrollmentDateGroup
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}