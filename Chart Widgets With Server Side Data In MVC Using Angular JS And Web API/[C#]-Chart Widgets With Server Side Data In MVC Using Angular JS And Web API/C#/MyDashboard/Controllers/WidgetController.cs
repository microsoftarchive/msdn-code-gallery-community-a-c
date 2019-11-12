using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyDashboard.Models;
using Newtonsoft.Json;
namespace MyDashboard.Controllers
{
    public class WidgetController : ApiController
    {
        public DashboardEntities de = new DashboardEntities();
        Retriever ret = new Retriever();
        public string getWidgetData()
        {
            var dataList = ret.GetWidgetData(de);
            return dataList;
        }
    }
}
