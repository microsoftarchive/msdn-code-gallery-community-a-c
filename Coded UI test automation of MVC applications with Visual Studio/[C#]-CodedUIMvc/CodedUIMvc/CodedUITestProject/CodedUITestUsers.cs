using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUITestProject
{
    [CodedUITest]
    public class CodedUITestUsers
    {
        public CodedUITestUsers()
        {
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Users.csv", "Users#csv", DataAccessMethod.Sequential), DeploymentItem("Users.csv")]
        public void CodedUITestCreate()
        {
            this.UIMap.RecordedMethodCreateNew();
            this.UIMap.AssertMethodCreateViewOpened();

            var uiCreate = this.UIMap.UIIndexCodedUItestautoWindow.UICreateCodedUItestautDocument;
            this.UIMap.RecordedMethodCreateParams.UIFirstNameEditText = TestContext.DataRow["FirstName"].ToString();
            this.UIMap.RecordedMethodCreateParams.UILastNameEditText = TestContext.DataRow["LastName"].ToString();
            this.UIMap.RecordedMethodCreateParams.UIEmailEditText = TestContext.DataRow["Email"].ToString();
            this.UIMap.RecordedMethodCreateParams.UIDateOfBirthEditText = TestContext.DataRow["DateOfBirth"].ToString();
            this.UIMap.RecordedMethodCreate();

            var uiIndex = this.UIMap.UIIndexCodedUItestautoWindow.UIIndexCodedUItestautoDocument;
            uiIndex.UIItemTable.UIBobCell.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = TestContext.DataRow["FirstName"].ToString();
            uiIndex.UIItemTable.UIBobCell.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = TestContext.DataRow["LastName"].ToString();
            uiIndex.UIItemTable.UIBobCell.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = TestContext.DataRow["Email"].ToString();
            uiIndex.UIBobsmithsomedomaincoHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = TestContext.DataRow["DateOfBirth"].ToString();
            this.UIMap.AssertMethodUserCreated();
        }

        // Use TestInitialize to run code before running each test 
        [TestInitialize]
        public void MyTestInitialize()
        {
            this.UIMap.RecordedMethodIndex();
            this.UIMap.AssertMethodIndexPageLoaded();
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
        }

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
