<%@ Application Inherits="System.Web.HttpApplication" %>

<%@ Import namespace="System.Web.Security" %>
<%@ Import namespace="System.Text.RegularExpressions" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Configuration" %>
<%@ Import namespace="System.Web.Routing" %>
<%@ Import namespace="System.Threading" %>
<%@ Import namespace="System.Globalization" %>
<%@ Import namespace="System.Security" %>
<%@ Import namespace="System.Web" %>
<%@ Import namespace="System.Web.Mvc" %>

<script language="C#" runat="server">


protected void Application_Start() {

	RouteTable.Routes.Clear();
	RouteTable.Routes.MapRoute(
		"Default", // Route name
		"{controller}/{action}/{id}", // URL with parameters
		new { controller = "Pdf", action = "DemoPage", id = UrlParameter.Optional } // Parameter defaults
	);

	
}

</script>