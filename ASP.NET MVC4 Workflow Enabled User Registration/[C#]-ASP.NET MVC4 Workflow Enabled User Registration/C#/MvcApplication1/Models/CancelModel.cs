namespace MvcApplication1.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CancelModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }
    }
}