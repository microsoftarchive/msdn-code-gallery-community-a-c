<%@ Page Language="C#" AutoEventWireup="true" Trace="true" TraceMode="SortByCategory" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET Diagnostic Page</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <h2>Environment Variables</h2>
    <pre>
    <table>    
<%
        var variables = Environment.GetEnvironmentVariables();
        foreach (DictionaryEntry entry in variables)
        {
            Response.Write("<tr><td>");
            Response.Write(entry.Key);
            Response.Write("</td><td>");
            Response.Write(entry.Value);
            Response.Write("</td></tr>");
        }
    %>
    </table>
    </pre>

    <h2>Misc</h2>
    <pre>
    Response.Filter = <%= Request.Filter.ToString() %>
    Request.ApplicationPath = <%= Request.ApplicationPath %>
    Request.PhysicalApplicationPath = <%= Request.PhysicalApplicationPath %>
    Request.PhysicalPath = <%= Request.PhysicalPath %>
    Request.UrlReferrer = <%= Request.UrlReferrer %>
    Request.UserLanguages = <%= string.Join(",", (Request.UserLanguages ?? new string[0])) %>
    </pre>
    
    </form>
</body>
</html>
