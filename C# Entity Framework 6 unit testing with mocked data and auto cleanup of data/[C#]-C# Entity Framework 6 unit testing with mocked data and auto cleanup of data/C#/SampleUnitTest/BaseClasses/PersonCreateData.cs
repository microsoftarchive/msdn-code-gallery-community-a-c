using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibrary;
namespace SampleUnitTest
{
    /// <summary>
    /// WARNING: If you debug a unit test and terminate the debug session
    /// before the test finishes the data created will still remain in the
    /// database table because the event TeardownTestBase never fires because
    /// you terminated the debug session.
    /// </summary>
    public class PersonCreateData : TestBase
    {
        /// <summary>
        /// Create some data into our database which is later cleaned up
        /// in the TearDown event TeardownTestBase after each test finishes
        /// running.
        /// </summary>
        public void CreateMockData()
        {
            var female = AddSandboxEntity(CreateFemale());
            var male = AddSandboxEntity(CreateMale());

            AddSandboxEntity(CreatePerson("Karen", "Payne", female));
            AddSandboxEntity(CreatePerson("Mike", "Jones", male));

            DbContext.SaveChanges();

        }
        /// <summary>
        /// Creates a person to insert into the database
        /// </summary>
        /// <param name="first">First name</param>
        /// <param name="last">Last name</param>
        /// <param name="genderType">gender type e.g. male, female, other</param>
        /// <returns></returns>
        private Person CreatePerson(string first, string last, GenderType genderType)
        {
            return new Person
            {
                FirstName = first,
                LastName = last,
                GenderType = genderType,
                IsDeleted = false,
                GenderIdentifier = genderType.GenderIdentifier
            };
        }
        /// <summary>
        /// Create a new female
        /// </summary>
        /// <returns></returns>
        public GenderType CreateFemale()
        {
            return new GenderType { Gender = "Female" };
        }
        /// <summary>
        /// Create a new male
        /// </summary>
        /// <returns></returns>
        public GenderType CreateMale()
        {
            return new GenderType { Gender = "Male" };
        }
        /// <summary>
        /// Get an existing gender, not mocked up in CreateMockData
        /// </summary>
        /// <returns></returns>
        public GenderType ExistingFemale()
        {
            using (PersonEntities Entity = new PersonEntities())
            {
                return Entity.GenderTypes.FirstOrDefault(item => item.Gender == "Female");
            }
        }
        /// <summary>
        /// Change the first name of a person for testing
        /// </summary>
        /// <param name="person"></param>
        /// <param name="name"></param>
        public void SetFirstName(Person person, string name)
        {

            // add a new person and add to the Annihilate list for cleaned up in test tear down

            Person thePerson = DbContext
                .People
                .FirstOrDefault((p) => p.FirstName == name) ?? 
                               AddSandboxEntity(new Person() { FirstName = name });

            // assign person name above to the person passed in
            person.FirstName = thePerson.FirstName;

            DbContext.SaveChanges();

        }
    }
}
