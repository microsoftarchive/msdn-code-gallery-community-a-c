using System.ComponentModel.DataAnnotations;

namespace App.Domain
{
   public class Country
    {
       [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
