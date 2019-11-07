using System;
using System.Collections.Generic;
using System.Linq;
using App.BusinessObject;
using App.Common;
using App.DataAccess;
using App.DataAccess.Interfaces;
using App.Domain;
using Omu.ValueInjecter;

namespace App.UIServices
{

    public class StudentService : RepositoryBase, IStudentService
    {
        public StudentService(IDatabaseFactory DbFactory): base(DbFactory)
        {
        }

        public TransactionStatus CreateStudent(StudentBo studentBo)
        {
            var transactionStatus = new TransactionStatus();
            var student = BuiltStudentDomain(studentBo);

            student.StudentID = Guid.NewGuid();
            CemexDb.Student.Add(student);
            CemexDb.SaveChanges();

            return transactionStatus;
        }


        public List<CountryBo> GetCountryLookup()
        {
          var countries =   CemexDb.Country.ToList();

            return countries.Select(s => BuiltCountryBo(s)).ToList();
        }

        private Student BuiltStudentDomain(StudentBo studentBo)
        {
            return (Student)new Student().InjectFrom(studentBo);
        }

        private StudentBo BuiltStudentBo(Student student)
        {
            return (StudentBo)new StudentBo().InjectFrom(student);
        }

        private CountryBo BuiltCountryBo(Country country)
        {
            return (CountryBo)new CountryBo().InjectFrom(country);
        }

   
    }

}
