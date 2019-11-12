using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvcApplication1.Tests.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;

    using MvcApplication1.Controllers;
    using MvcApplication1.Models;

    [TestClass]
    public class AccountControllerTest
    {
        private const string TestUser = "testUser";

        private const string TestUserEmail = "testUser@tempuri.org";

        private const string TestUserPassword = "P@ssW0rd";

        /// <summary>
        /// Given
        /// * A valid RegisterModel
        /// When
        /// * AccountController.Register is invoked with the model
        /// Then
        /// * User is added to membership but not approved
        /// </summary>
        [TestMethod]
        public void RegisterShouldNotApproveUser()
        {
            // Arrange
            var controller = new AccountController();
            var model = new RegisterModel()
                {
                    UserName = TestUser,
                    Email = TestUserEmail,
                    Password = TestUserPassword,
                    ConfirmPassword = TestUserPassword
                };

            // Act
            controller.Register(model);

            // Assert
            var testUser = Membership.GetUser(TestUser);
            Assert.IsNotNull(testUser);
            Assert.IsFalse(!testUser.IsApproved);
        }

    }
}
