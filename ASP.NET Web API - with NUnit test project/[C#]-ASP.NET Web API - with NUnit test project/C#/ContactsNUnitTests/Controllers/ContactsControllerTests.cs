using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using ContactManager.Controllers;
using ContactManager.Models.Repository;
using NUnit.Framework;
using System.Web.Http;
using ContactManager.Models.Entities;

namespace ContactsNUnitTests
{
    /// <summary>
    /// Contains NUnit test cases for ContactsController
    /// </summary>
    [TestFixture]
    public class ContactsControllerTests
    {
        ContactsController contactsController;
        ContactRepository repository;
        
        int count;
        int contactId;
        
        [SetUp]
        public void Setup()
        {
            //create an instance of contactRepository
            repository = new ContactRepository();
            
            //Create an instance of controller by passing repository
            contactsController = new ContactsController(repository);
            
            //Number of records
            count = contactsController.Get().contacts.Count;
            
            //Pass contact ID and store the retrieved contact ID
            contactId = contactsController.Get(1).contact.Id;
        }

        [Test]
        public void GetAllContacts()
        {
          Assert.IsTrue(count > 0);
        }

        [Test]
        public void GetContact()
        {
          Assert.IsTrue(contactId.Equals(1));
        }
    }
}
