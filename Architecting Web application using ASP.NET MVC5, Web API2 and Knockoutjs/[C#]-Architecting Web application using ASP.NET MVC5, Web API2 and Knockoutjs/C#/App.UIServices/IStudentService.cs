using System.Collections.Generic;
using App.BusinessObject;
using App.Common;

namespace App.UIServices
{
   public interface IStudentService
    {
       TransactionStatus CreateStudent(StudentBo studentBo);
       List<CountryBo> GetCountryLookup();
    }
}
