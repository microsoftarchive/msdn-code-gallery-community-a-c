using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAngularJsQueryAndFilter.Models
{
    public class SampleInitializer : CreateDatabaseIfNotExists<SampleContext>
    {
        protected override void Seed(SampleContext context)
        {
            //the classifications
            var fiction = new Classification { Name = "fiction" };
            context.Classifications.Add(fiction);

            var nonFiction = new Classification { Name = "non-fiction" };
            context.Classifications.Add(nonFiction);

            //the publishers
            var vintage = new Publisher { Name = "Vintage" };
            context.Publishers.Add(vintage);

            var penguin = new Publisher { Name = "Penguin" };
            context.Publishers.Add(penguin);

            var abacus = new Publisher { Name = "Abacus" };
            context.Publishers.Add(abacus);

            //the authors
            var orwell = new Author { Name = "George Orwell" };
            context.Authors.Add(orwell);

            var banks = new Author { Name = "Iain Banks" };
            context.Authors.Add(banks);

            var gibson = new Author { Name = "William Gibson" };
            context.Authors.Add(gibson);

            var murakami = new Author { Name = "Haruki Murakami" };
            context.Authors.Add(murakami);

            //the books

            #region Banks
            var theWaspFactory = new Book
            {
                Title = "The Wasp Factory",
                Author = banks,
                Classification = fiction,
                Publisher = abacus
            };

            var theBusiness = new Book
            {
                Title = "The Business",
                Author = banks,
                Classification = fiction,
                Publisher = abacus
            };

            var excession = new Book
            {
                Title = "Excession",
                Author = banks,
                Classification = fiction,
                Publisher = abacus
            };

            var matter = new Book
            {
                Title = "Matter",
                Author = banks,
                Classification = fiction,
                Publisher = abacus
            };

            var rawSpirit = new Book
            {
                Title = "Raw Spirit",
                Author = banks,
                Classification = nonFiction,
                Publisher = abacus
            };

            context.Books.AddRange(new List<Book> { theWaspFactory, theBusiness, excession, matter, rawSpirit });

            #endregion

            #region Gibson
            var idoru = new Book
            {
                Title = "Idoru",
                Author = gibson,
                Classification = fiction,
                Publisher = penguin
            };

            var zeroHistory = new Book
            {
                Title = "Zero History",
                Author = gibson,
                Classification = fiction,
                Publisher = penguin
            };

            var spookCountry = new Book
            {
                Title = "Spook Country",
                Author = gibson,
                Classification = fiction,
                Publisher = penguin
            };

            var neuromancer = new Book
            {
                Title = "Neuromancer",
                Author = gibson,
                Classification = fiction,
                Publisher = penguin
            };

            var distrustThatParticularFlavor = new Book
            {
                Title = "Distrust that Particular Flavor",
                Author = gibson,
                Classification = nonFiction,
                Publisher = penguin
            };

            context.Books.AddRange(new List<Book> { idoru, zeroHistory, spookCountry, neuromancer, distrustThatParticularFlavor });
            #endregion

            #region Murakami
            var aWildSheepChase = new Book
            {
                Title = "A Wild Sheep Chase",
                Author = murakami,
                Classification = fiction,
                Publisher = vintage
            };

            var kafkaOnTheShore = new Book
            {
                Title = "Kafka on the Shore",
                Author = murakami,
                Classification = fiction,
                Publisher = vintage
            };

            var Q84 = new Book
            {
                Title = "1q84",
                Author = murakami,
                Classification = fiction,
                Publisher = vintage
            };

            var afterTheQuake = new Book
            {
                Title = "After The Quake",
                Author = murakami,
                Classification = nonFiction,
                Publisher = vintage
            };

            var whatITalkAboutWhenITalkAboutRunning = new Book
            {
                Title = "What I Talk About When I Talk About Running",
                Author = murakami,
                Classification = nonFiction,
                Publisher = vintage
            };

            context.Books.AddRange(new List<Book> { aWildSheepChase, kafkaOnTheShore, Q84, afterTheQuake, whatITalkAboutWhenITalkAboutRunning });

            #endregion

            #region Orwell
            var nineteenEightyFour = new Book
            {
                Title = "1984",
                Author = orwell,
                Classification = fiction,
                Publisher = penguin
            };

            var animalFarm = new Book
            {
                Title = "Animal Farm",
                Author = orwell,
                Classification = fiction,
                Publisher = penguin
            };

            var shootingAnElephant = new Book
            {
                Title = "Shooting an Elephant",
                Author = orwell,
                Classification = nonFiction,
                Publisher = penguin
            };

            var seeingThingsAsTheyAre = new Book
            {
                Title = "Seeing Things as They Are",
                Author = orwell,
                Classification = nonFiction,
                Publisher = penguin
            };

            var theRoadToWiganPier = new Book
            {
                Title = "The Road to Wigan Pier",
                Author = orwell,
                Classification = nonFiction,
                Publisher = penguin
            };

            context.Books.AddRange(new List<Book> { nineteenEightyFour, animalFarm, shootingAnElephant, seeingThingsAsTheyAre, theRoadToWiganPier });

            #endregion
        }
    }
}
