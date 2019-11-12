using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{   
    public class ClientsController : Controller
    {
		private readonly IClientsRepository clientsRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ClientsController() : this(new ClientsRepository())
        {
        }

        public ClientsController(IClientsRepository clientsRepository)
        {
			this.clientsRepository = clientsRepository;
        }

        //
        // GET: /Clients/

        public ViewResult Index()
        {
            return View(clientsRepository.AllIncluding(clients => clients.Contacts));
        }

        //
        // GET: /Clients/Details/5

        public ViewResult Details(int id)
        {
            return View(clientsRepository.Find(id));
        }

        //
        // GET: /Clients/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Clients/Create

        [HttpPost]
        public ActionResult Create(Clients clients)
        {
            if (ModelState.IsValid) {
                clientsRepository.InsertOrUpdate(clients);
                clientsRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Clients/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(clientsRepository.Find(id));
        }

        //
        // POST: /Clients/Edit/5

        [HttpPost]
        public ActionResult Edit(Clients clients)
        {
            if (ModelState.IsValid) {
                clientsRepository.InsertOrUpdate(clients);
                clientsRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Clients/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(clientsRepository.Find(id));
        }

        //
        // POST: /Clients/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            clientsRepository.Delete(id);
            clientsRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                clientsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

