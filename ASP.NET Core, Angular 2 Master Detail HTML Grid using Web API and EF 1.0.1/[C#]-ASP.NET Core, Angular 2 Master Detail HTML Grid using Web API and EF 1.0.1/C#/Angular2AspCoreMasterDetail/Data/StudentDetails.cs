using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Angular2AspCoreMasterDetail.Data
{
    public class StudentDetails
    {
		[Key]
		public int StdDtlID { get; set; }

		[Required]
		[Display(Name = "StudentID")]
		public int StdID { get; set; }

		[Required]
		[Display(Name = "Major")]
		public string Major { get; set; }

		[Required]
		[Display(Name = "Year")]
		public string Year { get; set; }

		[Required]
		[Display(Name = "Term")]
		public string Term { get; set; }

		public string Grade { get; set; }
	}
}
