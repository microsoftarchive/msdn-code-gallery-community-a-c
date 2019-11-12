using Angular2MVC.DBContext;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Angular2MVC.Controllers
{
    public class EmployeeAPIController : BaseAPIController
    {
        public HttpResponseMessage Get()
        {
            return ToJson(EmployeeDB.TblEmployees.AsEnumerable());
        }

       public HttpResponseMessage Post([FromBody]TblEmployee value)
        {
            EmployeeDB.TblEmployees.Add(value);             
            return ToJson(EmployeeDB.SaveChanges());
        }

        public HttpResponseMessage Put(int id, [FromBody]TblEmployee value)
        {
            EmployeeDB.Entry(value).State = EntityState.Modified;
            return ToJson(EmployeeDB.SaveChanges());
        }
        public HttpResponseMessage Delete(int id)
        {
            EmployeeDB.TblEmployees.Remove(EmployeeDB.TblEmployees.FirstOrDefault(x => x.Id == id));
            return ToJson(EmployeeDB.SaveChanges());
        }
    }
}
