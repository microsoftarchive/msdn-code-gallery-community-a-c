using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainWeb.Helpers;

namespace MainWeb.Tests.Crypto
{
    [TestClass]
    public class KeyGenTests
    {
        [TestMethod]
        public void Generate_Simple_Hash()
        {
            //arrange
            KeyGen keygen = new KeyGen();

            //act
            var r1 = keygen.GetHash("test.docx");
            var r2 = keygen.GetHash("test.docx");

            //assert
            Assert.AreNotEqual(r2, r1, "hash shouldn't match");

        }

        [TestMethod]
        public void Generate_Simple_Hash_WithSalt()
        {
            //arrange
            KeyGen keygen = new KeyGen();

            //act
            var r1 = keygen.GetHash("test.docx");
            var salt = r1.Substring(0, 8 + 4);
            var r2 = keygen.GetHash("test.docx", salt);
            var b1 = keygen.Validate("test.docx", r1);

            //assert
            Assert.AreEqual(r1, r2, "hash not same");
            Assert.IsTrue(b1, "Hash failed");
        }
    }
}
