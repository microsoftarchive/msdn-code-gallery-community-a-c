using System;
using System.Collections.ObjectModel;
using System.Web.Http.Description;

namespace WebApiHelpPage
{
    partial class Index
    {
        public Collection<ApiDescription> Model { get; set; }

        public Func<string, string> ApiLinkFactory { get; set; }
    }
}