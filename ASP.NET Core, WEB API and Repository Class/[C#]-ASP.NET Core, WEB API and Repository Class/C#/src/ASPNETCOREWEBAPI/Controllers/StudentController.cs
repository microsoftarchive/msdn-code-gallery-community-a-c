using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCOREWEBAPI.Models;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNETCOREWEBAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private List<StudentMasters> _stdInfo;

        public StudentController()
        {
            InitializeData();
        }


        //This will return all Student Information
        [HttpGet]
        public IEnumerable<StudentMasters> GetAll()
        {
            return _stdInfo;
        }


        //To bind initial Student Information
        private void InitializeData()
        {
            _stdInfo = new List<StudentMasters>();

            var studentInfo1 = new StudentMasters
            {
                StdName = "Shanu",
                Phone = "+821039120700",
                Email = "syedshanumcain@gmail.com",
                Address = "Seoul,Korea"
            };

            var studentInfo2 = new StudentMasters
            {
                StdName = "Afraz",
                Phone = "+821000000700",
                Email = "afraz@gmail.com",
                Address = "Madurai,India"
            };

            var studentInfo3 = new StudentMasters
            {
                StdName = "Afreen",
                Phone = "+821012340700",
                Email = "afreen@gmail.com",
                Address = "Chennai,India"
            };

            _stdInfo.Add(studentInfo1);
            _stdInfo.Add(studentInfo2);
            _stdInfo.Add(studentInfo3);
        }
    }
}
