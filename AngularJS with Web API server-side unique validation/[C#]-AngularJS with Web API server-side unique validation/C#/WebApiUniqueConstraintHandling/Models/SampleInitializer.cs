using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiUniqueConstraintHandling.Models
{
    public class SampleInitializer : CreateDatabaseIfNotExists<SampleContext>
    {
        protected override void Seed(SampleContext context)
        {
 

            var TheWaspFactory = new Book
            {
                Title = "The Wasp Factory",
                Author = "Ian Banks" 
            };
            

            var TheDifferenceEngine = new Book
            {
                Title = "Idoru",
                Author = "William Gibson"
            };

            var TheDrownedWorld = new Book
            {
                Title = "The Drowned World",
                Author = "J G Ballard"
            };

            context.Books.AddRange(new List<Book> { 
                TheWaspFactory,
                TheDifferenceEngine,
                TheDrownedWorld
            });
        }
    }
}
