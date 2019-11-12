using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityLibrary;
using System.Linq;

namespace SampleUnitTest
{
    [TestClass]
    public class PeopleTest : PersonCreateData
    {
        /// <summary>
        /// When asking for first person the first name should be Karen
        /// </summary>
        [TestTraits(Trait.People)]
        [TestMethod()]
        public void FindPersonByFirstName()
        {

            CreateMockData();

            // get a mocked person
            var Person = GetSandboxEntities<Person>().FirstOrDefault();

            // validate they exist with first name of karen
            Assert.IsTrue(Person.FirstName == "Karen");

            // change Karen to Mary
            SetFirstName(Person, "Mary");
            Assert.IsFalse(Person.FirstName == "Karen");

        }
        /// <summary>
        /// Check count of Person records equals how many were created
        /// in CreateMockData
        /// </summary>
        [TestTraits(Trait.People)]
        [TestMethod()]
        public void PeopleCount()
        {

            CreateMockData();

            var thePeople = GetSandboxEntities<Person>();

            // assert there are two records matching mocked data
            Assert.AreEqual(2, thePeople.Count());
        }
        /// <summary>
        /// Get by first/last name and gender
        /// </summary>
        [TestTraits(Trait.People)]
        [TestMethod()]
        public void ValidateIsFemale()
        {

            CreateMockData();

            // get Karen Payne and check gender type is female
            var Person = GetSandboxEntities<Person>().Where((p) => {
                return p.FirstName == "Karen" && p.LastName == "Payne";
            }).FirstOrDefault();

            Assert.IsTrue(Person.GenderType.Gender == "Female");

        }
    }
}
