using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net.Http.Formatting;
using ContactManager.Models;
using System.Web.Http.Routing;

namespace ContactManager.Filters
{
    public class ContactSelfLinkFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var response = actionExecutedContext.Response;
            Contact contact = null;
            if (response.TryGetContentValue<Contact>(out contact))
            {
                AddSelfLink(contact, actionExecutedContext);
            }

            IEnumerable<Contact> contacts = null;
            if (response.TryGetContentValue<IEnumerable<Contact>>(out contacts))
            {
                var objectContent = (ObjectContent<IEnumerable<Contact>>)actionExecutedContext.Response.Content;
                objectContent.Value = contacts.Select(c => AddSelfLink(c, actionExecutedContext)).AsQueryable();
            }
        }

        Uri GetContactLink(int contactId, HttpActionExecutedContext context)
        {
            var routeData = context.Request.GetRouteData();
            var controller = routeData.Values["controller"];
            var urlHelper = context.Request.GetUrlHelper();
            return new Uri(urlHelper.Route("DefaultApi", new { controller = controller, id = contactId }), UriKind.Relative);
        }

        Contact AddSelfLink(Contact contact, HttpActionExecutedContext context)
        {
            contact.Self = GetContactLink(contact.ContactId, context).ToString();
            return contact;
        }
    }
}