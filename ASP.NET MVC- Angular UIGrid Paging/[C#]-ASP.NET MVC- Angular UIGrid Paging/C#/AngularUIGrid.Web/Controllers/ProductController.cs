using AngularUIGrid.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AngularUIGrid.Web.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private dbUIGrid_Entities _ctx = null;

        [HttpGet, ResponseType(typeof(tblProduct)), Route("GetProducts/{pageNumber:int}/{pageSize:int}")]
        public IHttpActionResult GetProducts(int pageNumber, int pageSize)
        {
            List<tblProduct> productList = null; int recordsTotal = 0;
            try
            {
                using (_ctx = new dbUIGrid_Entities())
                {
                    recordsTotal = _ctx.tblProducts.Count();
                    productList = _ctx.tblProducts.OrderBy(x => x.ProductID)
                                         .Skip(pageNumber)
                                         .Take(pageSize)
                                         .ToList();
                }
            }
            catch (Exception)
            {
            }
            return Json(new
            {
                recordsTotal,
                productList
            });
        }
    }
}
