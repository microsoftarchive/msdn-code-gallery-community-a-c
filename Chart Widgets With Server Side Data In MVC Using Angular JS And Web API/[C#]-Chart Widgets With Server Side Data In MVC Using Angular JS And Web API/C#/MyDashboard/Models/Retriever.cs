using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDashboard.Models
{
    public class Retriever
    {
        public string GetWidgetData(DashboardEntities de)
        {
            try
            {
                using (de)
                {
                    var resList = (from sales in de.SalesOrderDetails
                                  join prod in de.Products
                                  on sales.ProductID equals prod.ProductID
                                  select new
                                  {
                                      ProductName = prod.Name,
                                      QuantityOrdered = sales.OrderQty
                                  });
                    var res = resList.GroupBy(d => d.ProductName).Select(g => new
                    {
                        name = g.FirstOrDefault().ProductName,
                        y = g.Sum(s => s.QuantityOrdered)
                    });
                    return JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }
    }
}