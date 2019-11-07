<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcRestApi.Models.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	NewCustomer
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <small><%= Html.ActionLink("<< Customers", "Index", "Customers") %></small>

    <h2>NewCustomer</h2>

    <%= Html.ValidationSummary() %>
<pre>
<% using (Html.BeginForm())
   { %>
<%= Html.LabelFor(customer => customer.Name)%>: <%= Html.TextBoxFor(customer => customer.Name)%> <%= Html.ValidationMessageFor(customer => customer.Name) %>
<%= Html.LabelFor(customer => customer.Country)%>: <%= Html.TextBoxFor(customer => customer.Country)%> <%= Html.ValidationMessageFor(customer => customer.Country) %>

<input type="submit" name="verb" value="Add" /> 
<% } %>

</pre>
<%= ViewData["Message"] ?? "" %>

<% Html.RenderPartial("Shared/XmlViewer"); %>

<% Html.RenderPartial("Shared/JsonViewer"); %>

<script type="text/javascript">
    $(document).ready(function () {
        $("#jsonAdditionalQueryString").val("");
        $("#xmlAdditionalQueryString").val("");
    });
</script>

</asp:Content>
