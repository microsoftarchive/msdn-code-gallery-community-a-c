<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcRestApi.Models.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SingleCustomer
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <small><%= Html.ActionLink("<< Customers", "Index", "Customers") %></small>

    <h2>Customer Details</h2>
    <%= Html.ValidationSummary() %>

<% using (Html.BeginForm())
   { %>
   <fieldset title="Customer Details">
<p><%= Html.LabelFor(customer => customer.CustomerId)%>: <%= Html.DisplayFor(customer => customer.CustomerId)%> </p>
<p><%= Html.LabelFor(customer => customer.Name)%>: <%= Html.TextBoxFor(customer => customer.Name)%> <%= Html.ValidationMessageFor(customer => customer.Name) %></p>
<p><%= Html.LabelFor(customer => customer.Country)%>: <%= Html.TextBoxFor(customer => customer.Country)%> <%= Html.ValidationMessageFor(customer => customer.Country) %></p>
    </fieldset>
<input type="submit" name="verb" value="Save" /> <input type="submit" name="verb" value="Delete" />
<% } %>


<%= ViewData["Message"] ?? "" %>

<p>
<%= Html.RouteLink("Orders", "CustomerOrders", new { customerId = Model.CustomerId })%>
</p>

<% Html.RenderPartial("Shared/XmlViewer"); %>

<% Html.RenderPartial("Shared/JsonViewer"); %>
</asp:Content>
