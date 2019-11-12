using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularJsQueryAndFilter.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new List<Book>();
        }

        [Key]
        public virtual int Id { get; set; }

        [Index(IsUnique = true)]        
        [MaxLength(255)]
        [MinLength(1)]
        [Required]
        public virtual string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
