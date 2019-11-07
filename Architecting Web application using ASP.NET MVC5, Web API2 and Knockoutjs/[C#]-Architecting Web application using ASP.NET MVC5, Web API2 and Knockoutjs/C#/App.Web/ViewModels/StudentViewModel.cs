using System;
using App.Common;

namespace App.Web.ViewModels
{
    public class StudentViewModel : TransactionStatus
    {
        public Guid StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string[] SelectedPaymentMethods { get; set; }
        public int CountryId { get; set; }
        public string SelectedGender { get; set; }
        public string Remarks { get; set; }
        
    }
}