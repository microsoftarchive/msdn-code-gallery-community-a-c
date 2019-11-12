using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BTL.Application.Web.Infrastructure.Extensions
{
    public static class DisplayExtensions
    {
        public static MvcHtmlString DisplayMessage(this HtmlHelper htmlHelper)
        {
            var tempmessages = htmlHelper.ViewContext.TempData["MessageForView"];
            if (tempmessages == null) return MvcHtmlString.Create(string.Empty);

            var messages = (List<ErrorMessage>)tempmessages;

            var error = "<ul class=\"message\">";

            error = messages.Aggregate(error, (s, mes) =>
            {
                s += "<li>" + mes.Message + "</li>";
                return s;
            });

            error += "</ul>";

            return MvcHtmlString.Create(error);
        }
    }
}