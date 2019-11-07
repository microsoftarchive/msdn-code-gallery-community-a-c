<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GroupDocsViewerWebFormsSample.Default" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="GroupDocsViewerWebFormsSample" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Main page</title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>GroupDocs.Viewer for .NET version <%=typeof(Groupdocs.Web.UI.Viewer).Assembly.GetName().Version.ToString() %></h3>
        <h4>Working in <%= Groupdocs.Web.UI.Viewer.IsLicensed ? "licensed (full)" : "unlicensed (trial)" %> mode</h4>
    <table border="0" cellpadding="5" cellspacing="5">
    <thead>
        <tr>
            <td>Filename</td>
            <td>Size</td>
            <td>Display in image-based mode</td>
            <td>Display in HTML-based mode</td>
        </tr>
    </thead>
    <tbody>
        <% foreach (string one_document in FileRepository.GetAllDocuments())
           {%>
             <tr>
                 <td>
                     <%= one_document %>
                 </td>
                 <td>
                     <%= new FileInfo(FileRepository.RootStorage+one_document).Length / 1024 %> KB
                 </td>
                 <td>
                     <a href="Viewer.aspx?Doc=<%= one_document %>&Mode=1">Open</a>
                 </td>
                 <td>
                     <a href="Viewer.aspx?Doc=<%= one_document %>&Mode=2">Open</a>
                 </td>
             </tr>  
                   
           <%} %>
    </tbody>
</table>
    
    </form>
</body>
</html>
