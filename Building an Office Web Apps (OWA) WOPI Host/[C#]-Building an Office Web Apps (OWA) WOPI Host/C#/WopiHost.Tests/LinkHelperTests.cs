using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainWeb.Helpers;

namespace MainWeb.Tests
{
    [TestClass]
    public class LinkHelperTests
    {
        [TestMethod]
        public void Generate_Word_Zone()
        {
            WopiAppHelper linkHelper = new WopiAppHelper("Discovery.xml");

            var obj = linkHelper.GetZone("Word");

            Assert.IsNotNull(obj);

        }

        [TestMethod]
        public void Get_Word_Doc_Link()
        {
            WopiAppHelper linkHelper = new WopiAppHelper("Discovery.xml");

            var wopiHostLink = "http://wopi2.com/api/wopi/files/test.docx";

            var obj = linkHelper.GetDocumentLink("Word", "docx", wopiHostLink, "tbd");

            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public void Get_Excel_Doc_Link()
        {
            WopiAppHelper linkHelper = new WopiAppHelper("Discovery.xml");

            var wopiHostLink = "http://wopi2.com/api/wopi/files/test.xls";

            var obj = linkHelper.GetDocumentLink("Excel", "xls", wopiHostLink, "tbd");

            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public void TestTest()
        {
            WopiAppHelper linkHelper = new WopiAppHelper("Discovery.xml");
            var wopiHostLink = "http://wopi2.com/api/wopi/files/test.docx";
            linkHelper.GetDocumentLink(wopiHostLink);
        }
    }
}
