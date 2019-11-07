using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AjaxForm.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "*"), EmailAddress(ErrorMessage = "Not valid")]
        public string Email { get; set; }
    }
}