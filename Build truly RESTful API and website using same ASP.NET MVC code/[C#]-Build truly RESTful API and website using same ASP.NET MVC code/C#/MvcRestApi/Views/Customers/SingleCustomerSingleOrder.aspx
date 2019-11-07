<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcRestApi.Models.Order>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SingleCustomerSingleOrder
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <small><%= Html.RouteLink("<< Orders", "CustomerOrders", new { customerId = (string)ViewContext.RouteData.Values["customerId"], orderId = UrlParameter.Optional })%></small>
    <h2>Order Details</h2>

    <% using (Html.BeginForm())
       { %>

    <fieldset title="Order Details" >
    <p><%= Html.LabelFor(order => order.OrderId)%>: <%= Html.DisplayFor(order => order.OrderId)%></p>
    <p><%= Html.LabelFor(order => order.ProductName)%>: <%= Html.TextBoxFor(order => order.ProductName)%></p>
    <p><%= Html.LabelFor(order => order.ProductPrice)%>: <%= Html.TextBoxFor(order => order.ProductPrice)%></p>
    <p><%= Html.LabelFor(order => order.ProductQuantity)%>: <%= Html.TextBoxFor(order => order.ProductQuantity)%></p>
    </fieldset>
    <input type="submit" name="verb" value="Save" /> <input type="submit" name="verb" value="Delete" />
    <% } %>

    <p><%= ViewData["Message"] ?? "" %></p>

<% Html.RenderPartial("Shared/XmlViewer"); %>

<% Html.RenderPartial("Shared/JsonViewer"); %>

</asp:Content>
