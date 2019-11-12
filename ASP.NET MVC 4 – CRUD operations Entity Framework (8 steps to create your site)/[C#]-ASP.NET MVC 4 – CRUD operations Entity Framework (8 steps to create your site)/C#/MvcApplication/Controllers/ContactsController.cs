using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{   
    public class ContactsController : Controller
    {
		private readonly IClientsRepository clientsRepository;
		private readonly IContactsRepository contactsRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ContactsController() : this(new ClientsRepository(), new ContactsRepository())
        {
        }

        public ContactsController(IClientsRepository clientsRepository, IContactsRepository contactsRepository)
        {
			this.clientsRepository = clientsRepository;
			this.contactsRepository = contactsRepository;
        }

        //
        // GET: /Contacts/

        public ViewResult Index()
        {
            return View(contactsRepository.AllIncluding(contacts => contacts.Client));
        }

        //
        // GET: /Contacts/Details/5

        public ViewResult Details(int id)
        {
            return View(contactsRepository.Find(id));
        }

        //
        // GET: /Contacts/Create

        public ActionResult Create()
        {
			ViewBag.PossibleClients = clientsRepository.All;
            return View();
        } 

        //
        // POST: /Contacts/Create

        [HttpPost]
        public ActionResult Create(Contacts contacts)
        {
            if (ModelState.IsValid) {
                contactsRepository.InsertOrUpdate(contacts);
                contactsRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleClients = clientsRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Contacts/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleClients = clientsRepository.All;
             return View(contactsRepository.Find(id));
        }

        //
        // POST: /Contacts/Edit/5

        [HttpPost]
        public ActionResult Edit(Contacts contacts)
        {
            if (ModelState.IsValid) {
                contactsRepository.InsertOrUpdate(contacts);
                contactsRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleClients = clientsRepository.All;
				return View();
			}
        }

        //
        // GET: /Contacts/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(contactsRepository.Find(id));
        }

        //
        // POST: /Contacts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            contactsRepository.Delete(id);
            contactsRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                clientsRepository.Dispose();
                contactsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

