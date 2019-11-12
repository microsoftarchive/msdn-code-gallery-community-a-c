using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.ServiceModel;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;

namespace CodeFirstNorthwind
{
    // We need to use an ObjectContext, which we provide manually.
    public class Northwind : DataService<ObjectContext>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // We need to explicitly set the less restrictive rights.
            config.SetEntitySetAccessRule("Orders", EntitySetRights.All);
            config.SetEntitySetAccessRule("OrderDetails", EntitySetRights.All);
            
            // Set the remaining entity sets to read all.
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }

        // We must override CreateDataSource to manually return an ObjectContext,
        // otherwise the runtime tries to use the built-in reflection provider instead of 
        // the Entity Framework provider.
        protected override ObjectContext CreateDataSource()
        {
            NorthwindContext nw = new NorthwindContext();
 
            // Configure DbContext before we provide it to the 
            // data services runtime.
            nw.Configuration.ValidateOnSaveEnabled = false;

            // Get the underlying ObjectContext for the DbContext.
            var context = ((IObjectContextAdapter)nw).ObjectContext;

            // Return the underlying context.
            return context;
        }       
    }
}
