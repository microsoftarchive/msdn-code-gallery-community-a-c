using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiUniqueConstraintHandling.Models
{
    public class Book
    {
        public Book()
        {       
        }

        [Key]
        public virtual int Id { get; set; }

        [Index(IsUnique = true)]        
        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public virtual string Title { get; set; }

        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public string Author { get; set; }
    }
}
