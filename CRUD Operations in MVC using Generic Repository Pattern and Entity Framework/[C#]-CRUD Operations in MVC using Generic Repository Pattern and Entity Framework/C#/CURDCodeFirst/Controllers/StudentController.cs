using CF.Data;
using CF.Repo;
using CURDCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CURDCodeFirst.Controllers
{
    public class StudentController : Controller
    {
        private UnitOfWork unitOfWork;
        private Repository<Student> studentRepository;

        public StudentController()
        {
            unitOfWork = new UnitOfWork();
            studentRepository = unitOfWork.Repository<Student>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<StudentViewModel> students = studentRepository.Table.AsEnumerable().Select(s => new StudentViewModel
            {
                Id = s.Id,
                Name = $"{s.FirstName} {s.LastName}",
                Email = s.Email,
                EnrollmentNo = s.EnrollmentNumber
            });
            return View(students);
        }

        [HttpGet]
        public PartialViewResult AddEditStudent(long? id)
        {
            StudentViewModel model = new StudentViewModel();
            if (id.HasValue)
            {
                Student student = studentRepository.GetById(id.Value);
                model.Id = student.Id;
                model.FirstName = student.FirstName;
                model.LastName = student.LastName;
                model.EnrollmentNo = student.EnrollmentNumber;
                model.Email = student.Email;
            }
            return PartialView("~/Views/Student/_AddEditStudent.cshtml", model);
        }

        [HttpPost]
        public ActionResult AddEditStudent(long? id, StudentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Student student = isNew ? new Student
                    {
                        AddedDate = DateTime.UtcNow
                    } : studentRepository.GetById(id.Value);
                    student.FirstName = model.FirstName;
                    student.LastName = model.LastName;
                    student.EnrollmentNumber = model.EnrollmentNo;
                    student.Email = model.Email;
                    student.IPAddress = Request.UserHostAddress;
                    student.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        studentRepository.Insert(student);
                    }
                    else
                    {
                        studentRepository.Update(student);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult DeleteStudent(long id)
        {
            Student student = studentRepository.GetById(id);
            StudentViewModel model = new StudentViewModel
            {
                Name = $"{student.FirstName} {student.LastName}"
            };
            return PartialView("~/Views/Student/_DeleteStudent.cshtml", model);
        }
        [HttpPost]
        public ActionResult DeleteStudent(long id, FormCollection form)
        {
            Student student = studentRepository.GetById(id);
            studentRepository.Delete(student);
            return RedirectToAction("Index");
        }
    }
}