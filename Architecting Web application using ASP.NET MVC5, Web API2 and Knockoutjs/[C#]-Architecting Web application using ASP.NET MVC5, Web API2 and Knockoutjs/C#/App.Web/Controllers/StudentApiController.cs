using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Util;
using App.BusinessObject;
using App.Common;
using App.UIServices;
using App.Web.ModelValidation;
using App.Web.ViewModels;
using Newtonsoft.Json;
using Omu.ValueInjecter;

namespace App.Web.Controllers
{
 
    [RoutePrefix("api/students")]
    public class StudentApiController : ApiController
    {
        readonly IStudentService _studentService;       

        public StudentApiController(IStudentService studentService)
        {
            _studentService = studentService;           
        }


        [HttpGet("allcountries")]
        public HttpResponseMessage GetLookupCountry()
        {
            var countires = _studentService.GetCountryLookup();
            var badResponse = Request.CreateResponse(HttpStatusCode.OK, countires);

            return badResponse;
        }

        [HttpPost("create")]
        public HttpResponseMessage CreateStudent(StudentViewModel studentViewModel)
        {
            TransactionStatus transactionStatus;
            var results = new StudentValidation().Validate(studentViewModel);

            if (!results.IsValid)
            {
                studentViewModel.Errors = GenerateErrorMessage.Built(results.Errors);
                studentViewModel.ErrorType =ErrorTypeEnum.Error.ToString().ToLower();
                studentViewModel.Status = false;
                var badResponse = Request.CreateResponse(HttpStatusCode.BadRequest, studentViewModel);
                return badResponse; 
            }

            var stundentBo = BuiltStudentBo(studentViewModel);
            stundentBo.PaymentMethods = string.Join(",", studentViewModel.SelectedPaymentMethods);
            stundentBo.Gender = studentViewModel.SelectedGender;

            transactionStatus = _studentService.CreateStudent(stundentBo);
            
            if (transactionStatus.Status == false)
            {
                var badResponse = Request.CreateResponse(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(studentViewModel));
                return badResponse;
            }
            else
            {
                transactionStatus.ErrorType = ErrorTypeEnum.Success.ToString();
                transactionStatus.ReturnMessage.Add("Record successfully inserted to database");

                var badResponse = Request.CreateResponse(HttpStatusCode.Created, transactionStatus);

                return badResponse;
            }
        }

        private StudentBo BuiltStudentBo(StudentViewModel studentViewModel)
        {
            return (StudentBo)new StudentBo().InjectFrom(studentViewModel);
        }

    }
}
