using ContactManager.Controllers.Apis;
using ContactManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;

namespace ContactManager.Tests.Controllers
{
    [TestClass]
    public class ContactsTest
    {
        [TestMethod]
        public void GetContacts()
        {
            var controller = new ContactsController(new SampleContactRepository());
            var contacts = controller.Get();
            Assert.IsTrue(contacts.Count() > 0);
        }

        [TestMethod]
        public void Post()
        {
            // Post should return a contact
            var config = new HttpConfiguration();
            var kernel = new StandardKernel();
            kernel.Bind<IContactRepository>().ToConstant(new SampleContactRepository());
            WebApiConfig.Register(config, kernel);
            var server = new HttpServer(config);
            var client = new HttpClient(server);
            var contact = new Contact() { Name = "Test" };
            var response = client.PostAsJsonAsync<Contact>("http://localhost/api/contacts", contact).Result;
            var postedContact = response.Content.ReadAsAsync<Contact>().Result;
            Assert.IsNotNull(postedContact);

            // Post response should include a valid location header
            response = client.GetAsync(response.Headers.Location).Result;
            contact = response.Content.ReadAsAsync<Contact>().Result;
            Assert.IsNotNull(contact);

        }

        [TestMethod]
        public void GetContact()
        {
            var controller = new ContactsController(new SampleContactRepository());
            int id = 1;
            var contact = controller.Get(id);
            Assert.AreEqual(id, contact.ContactId);
        }

        [TestMethod]
        public void Delete()
        {
            var repository = new SampleContactRepository();
            var controller = new ContactsController(repository);
            int id = 1;
            controller.Delete(id);
            Assert.IsNull(repository.Get(id));
        }
    }
}
