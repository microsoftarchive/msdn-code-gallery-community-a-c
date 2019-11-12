using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using OrdersAPI.Models;
using OrdersAPI.Dal;


namespace OrdersAPI.Controllers
{
    public class OrdersController : ApiController
    {

        #region GET
        public IHttpActionResult Get(string id)
        {
                       
            OrderManager mgr = new OrderManager();
            var order = mgr.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);           
        }
        #endregion

        #region POST
        public async Task<IHttpActionResult> Post([FromBody]ClientOrder order)
        {
            OrderResult result = new OrderResult();

            try
            {
                OrderManager mgr = new OrderManager();
                string id = await mgr.CreateOrder(order);

                if (id != null)
                {
                    result.Id = id;
                }

                //Return a HTTP 200 with the created id
                return Ok(result);
            }
            catch
            {
                return InternalServerError();
            }
        }
        #endregion

        #region PUT
        public async Task<IHttpActionResult> Put(string id, [FromBody]ClientOrder order)
        {
            try
            {
                OrderManager mgr = new OrderManager();
                string result = await mgr.UpdateOrderById(id, order);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok("Order updated");
            }
            catch
            {
                return InternalServerError();
            }
        }
        #endregion

        #region DELETE
        public async Task<IHttpActionResult> Delete(string id)
        {
            try
            {
                OrderManager mgr = new OrderManager();
                string result = await mgr.DeleteOrderById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok("Order deleted");
            }
            catch 
            {
                return InternalServerError();
            }            
        }
        #endregion
    }       
}
