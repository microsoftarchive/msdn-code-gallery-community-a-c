using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleUnitTest
{
    [TestClass()]
    public class TestBase
    {

        protected List<object> AnnihilationList;
        protected PersonEntities TheDbContext;
    
        public PersonEntities DbContext
        {
            get
            {
                return TheDbContext;
            }
            set
            {
                TheDbContext = value;
            }
        }

        [TestInitialize]
        public void SetupTestBase()
        {
            AnnihilationList = new List<object>();
            DbContext = new PersonEntities();
        }

        [TestCleanup]
        public void TeardownTestBase()
        {
            var success = AnnihilateData(AnnihilationList);
            DbContext.Dispose();

            if (!success)
            {
                throw new Exception("The database is now dirty! The unit test failed to dispose of its test data!");
            }
        }

        /// <summary>
        /// Gets all objects of the given type that exist in the annihilateList.
        /// </summary>
        /// <typeparam name="T">The type of objects to return</typeparam>
        /// <returns></returns>
        protected IEnumerable<T> GetSandboxEntities<T>()
        {
            var returnObject = (
                from item in AnnihilationList
                where item.GetType() == typeof(T)
                select (T)item);
            return returnObject;
        }

        /// <summary>
        /// Adds an entity object to the db context and the annihilateList.
        /// </summary>
        /// <typeparam name="T">An EF entity type</typeparam>
        /// <param name="sandboxEntity">
        /// An EF entity to add to the sandbox.
        /// </param>
        public T AddSandboxEntity<T>(T sandboxEntity) where T : class
        {
            DbContext.Set<T>().Add(sandboxEntity);
            AnnihilationList.Add(sandboxEntity);
            return sandboxEntity;
        }

        /// <summary>
        /// Adds an entity object to the db context and the annihilateList.
        /// </summary>
        /// <typeparam name="T">An EF entity type</typeparam>
        /// <param name="sandboxEntities">
        /// Enumerable of EF entities to add to the sandbox.
        /// </param>
        protected IEnumerable<T> AddSandboxEntities<T>(IEnumerable<T> sandboxEntities) where T : class
        {
            foreach (T entity in sandboxEntities)
            {
                AddSandboxEntity(entity);
            }
            return sandboxEntities;
        }
        /// <summary>
        /// Removes test data from database, called from all tests that create data
        /// </summary> 
        /// <remarks>
        /// If you have issues with data not disposing then set break-points
        /// in the emppty try/catch statements to figure out the issue. More likely
        /// than not the interface, in this case IBaseEntity was not implemented on
        /// one of the classes.
        /// 
        /// The try-catches allow us to continue and throw an exception message in
        /// the tear down event TeardownTestBase for any test.
        /// 
        /// Empty try/catches are okay here as you should be using this only for
        /// unit testing and hopefully on a non production database.
        /// 
        /// </remarks>
        public bool AnnihilateData(List<object> mAnnihilateList)
        {
            bool mAnnihilateDataSuccessful = false;

            using (var destroyContext = new PersonEntities())
            {

                for (int i = mAnnihilateList.Count - 1; i >= 0; i--)
                {
                    try
                    {
                        var currentObject = mAnnihilateList[i];

                        var existingItem = destroyContext
                            .Set(currentObject.GetType())
                            .Find(((IBaseEntity)currentObject).Identifier);

                        if (existingItem != null)
                        {
                            try
                            {
                                var attachedEntry = destroyContext.Entry(existingItem);
                                attachedEntry.CurrentValues.SetValues(currentObject);
                                destroyContext.Set(existingItem.GetType()).Attach(existingItem);

                                destroyContext.Set(existingItem.GetType()).Remove(existingItem);
                            }
                            catch (Exception)
                            {
                                // ignore nothing do to as the object was not added in properly.
                            }
                        }
                        else
                        {
                            var item = currentObject.GetType();
                        }
                    }
                    catch (Exception)
                    {
                        //catch and continue save what we can
                    }
                }
                try
                {

                    var resultCount = destroyContext.SaveChanges();
                    var annihlationCount = mAnnihilateList.Count;

                    mAnnihilateDataSuccessful = (resultCount == annihlationCount);

                }
                catch (Exception)
                {
                    // keep on going
                }
                finally
                {
                    destroyContext.Dispose();
                }
            }

            return mAnnihilateDataSuccessful;

        }
    }
}
