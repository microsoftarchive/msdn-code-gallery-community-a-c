using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain
{
    public class Student
    {
        [Key]
        public Guid StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PaymentMethods { get; set; }
        public string Remarks { get; set; }
        public int CountryId { get; set; }
        public string Gender { get; set; }
       
    }
}
