<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcRestApi.Models.Customer>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <h3>Customers</h3>
    <table>
        <thead>
            <th>Name</th>
            <th>Country</th>
            <th>Orders</th>
        </thead>

        <tbody>
        <% foreach (MvcRestApi.Models.Customer customer in Model)
           { %>
           <tr>
            <td><%= Html.RouteLink(customer.Name, "SingleCustomer", new { customerID = customer.CustomerId }) %></td>
            <td><%= customer.Country %></td>
            <td><%= Html.RouteLink("Orders", "CustomerOrders", new { customerID = customer.CustomerId }) %></td>
           </tr>
        <% } %>
        </tbody>
    </table>

    <p>
    <a href="?verb=New">Add New</a>
    </p>
    
<% Html.RenderPartial("Shared/XmlViewer"); %>

<% Html.RenderPartial("Shared/JsonViewer"); %>

</asp:Content>
