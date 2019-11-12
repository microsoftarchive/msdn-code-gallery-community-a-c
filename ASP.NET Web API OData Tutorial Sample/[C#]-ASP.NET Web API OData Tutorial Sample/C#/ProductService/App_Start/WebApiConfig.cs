using ProductService.Models;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace ProductService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Supplier>("Suppliers");
            builder.EntitySet<ProductRating>("Ratings");
            ActionConfiguration rateProduct = builder.Entity<Product>().Action("RateProduct");
            rateProduct.Parameter<int>("Rating");
            rateProduct.Returns<double>();

            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}