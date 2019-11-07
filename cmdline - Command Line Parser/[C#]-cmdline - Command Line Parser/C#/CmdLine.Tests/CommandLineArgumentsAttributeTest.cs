namespace CmdLine.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    ///<summary>
    ///  This is a test class for CommandLineArgumentsAttributeTest and is intended
    ///  to contain all CommandLineArgumentsAttributeTest Unit Tests
    ///</summary>
    [TestClass]
    public class CommandLineArgumentsAttributeTest
    {
        ///<summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GetShouldReturnCommandLineArgumentsAttribute()
        {
            var attribute = CommandLineArgumentsAttribute.Get(typeof(XCopyCommandArgs));
            Assert.IsNotNull(attribute);
            Assert.AreEqual(XCopyCommandArgs.Title, attribute.Title);
            Assert.AreEqual(XCopyCommandArgs.Description, attribute.Description);
        }

        [TestMethod]
        public void GetReturnsNullWhenNoAttribute()
        {
            var attribute = CommandLineArgumentsAttribute.Get(typeof(string));
            Assert.IsNull(attribute);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetThrowsArgumentNullWhenNull()
        {
            CommandLineArgumentsAttribute.Get(null);            
        }
    }
}