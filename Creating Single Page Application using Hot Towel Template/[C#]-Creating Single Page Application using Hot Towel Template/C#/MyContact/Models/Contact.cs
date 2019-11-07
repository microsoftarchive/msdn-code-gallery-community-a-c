using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyContact.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}",
            ErrorMessage = "Invalid mobile")]
        public string Mobile { get; set; }
        //TODO: Email validation string has to check - Artha
        [RegularExpression(
        @"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$",
            ErrorMessage = "Invalid email")]
        public string Email { get; set; }
    }
}