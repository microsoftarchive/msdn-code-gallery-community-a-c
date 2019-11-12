using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD_Using_Entity_Framework_Code_First
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
