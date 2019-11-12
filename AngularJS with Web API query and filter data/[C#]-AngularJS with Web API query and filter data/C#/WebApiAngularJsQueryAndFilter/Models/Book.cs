using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularJsQueryAndFilter.Models
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

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int ClassificationId { get; set; }

        public Classification Classification { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }
    }
}
