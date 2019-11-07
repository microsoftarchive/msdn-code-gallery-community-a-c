using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Demo1.Models;

namespace Demo1.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Cars
        public IActionResult Index()
        {
            return View(_context.Car.ToList());
        }

        // GET: Cars/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Car car = _context.Car.Single(m => m.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Car.Add(car);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Car car = _context.Car.Single(m => m.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Update(car);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Car car = _context.Car.Single(m => m.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Car car = _context.Car.Single(m => m.Id == id);
            _context.Car.Remove(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
