<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcRestApi.Models.Order>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SingleCustomerOrders
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <small><%= Html.RouteLink("<< Customer", "SingleCustomer", new { customerId = (string)ViewContext.RouteData.Values["customerId"] })%></small>
    <h2>Orders</h2>

    <table>
        <thead>
            <th>OrderId</th>
            <th>Name</th>
            <th>Price</th>
            <th>Quantity</th>
        </thead>

        <tbody>
        <% foreach (MvcRestApi.Models.Order order in Model)
           { %>
           <tr>
            <td><%= Html.RouteLink(order.OrderId, "CustomerOrders", 
                new { 
                    customerId = (string)ViewContext.RouteData.Values["customerId"],
                    orderId = order.OrderId 
                }) %></td>
            <td><%= order.ProductName %></td>
            <td><%= order.ProductPrice %></td>
            <td><%= order.ProductQuantity %></td>
           </tr>
        <% } %>
        </tbody>
    </table>

    <% Html.RenderPartial("Shared/XmlViewer"); %>

    <% Html.RenderPartial("Shared/JsonViewer"); %>

</asp:Content>
