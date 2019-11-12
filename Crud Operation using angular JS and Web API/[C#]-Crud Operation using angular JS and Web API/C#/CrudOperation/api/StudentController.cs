using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CrudOperation.api
{
    // Route 
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        // // StudentDBEntities object point
        StudentDBEntities dbContext = null;
        // Constructor 
        public StudentController()
        {
            // create instance of an object
            dbContext = new StudentDBEntities();
        }


        [ResponseType(typeof(tblStudent))]
        [HttpPost]
        public HttpResponseMessage SaveStudent(tblStudent astudent)
        {
            int result = 0;
            try
            {
                dbContext.tblStudents.Add(astudent);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [ResponseType(typeof(tblStudent))]
        [HttpPut]
        public HttpResponseMessage UpdateStudent(tblStudent astudent)
        {
            int result = 0;
            try
            {
                dbContext.tblStudents.Attach(astudent);
                dbContext.Entry(astudent).State = EntityState.Modified;
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [ResponseType(typeof(tblStudent))]
        [HttpDelete]
        public HttpResponseMessage DeleteStudent(int id)
        {
            int result = 0;
            try
            {
                var student = dbContext.tblStudents.Where(x => x.StudentID == id).FirstOrDefault();
                dbContext.tblStudents.Attach(student);
                dbContext.tblStudents.Remove(student);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("GetStudentByID/{studentID:int}")]
        [ResponseType(typeof(tblStudent))]
        [HttpGet]
        public tblStudent GetStudentByID(int studentID)
        {
            tblStudent astudent = null;
            try
            {
                astudent = dbContext.tblStudents.Where(x => x.StudentID == studentID).SingleOrDefault();

            }
            catch (Exception e)
            {
                astudent = null;
            }

            return astudent;
        }

        [ResponseType(typeof(tblStudent))]
        [HttpGet]
        public List<tblStudent> GetStudents()
        {
            List<tblStudent> students = null;
            try
            {
                students = dbContext.tblStudents.ToList();

            }
            catch (Exception e)
            {
                students = null;
            }

            return students;
        }



    }
}
