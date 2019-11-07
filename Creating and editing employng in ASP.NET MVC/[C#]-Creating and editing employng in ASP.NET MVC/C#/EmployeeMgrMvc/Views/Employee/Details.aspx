<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EmployeeMgrMvc.Models.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Employee Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">EmployeeID</div>
        <div class="display-field"><%: Model.EmployeeID %></div>
        
        <div class="display-label">LastName</div>
        <div class="display-field"><%: Model.LastName %></div>
        
        <div class="display-label">FirstName</div>
        <div class="display-field"><%: Model.FirstName %></div>
        
        <div class="display-label">Title</div>
        <div class="display-field"><%: Model.Title %></div>
        
        <div class="display-label">BirthDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.BirthDate) %></div>
        
        <div class="display-label">HireDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.HireDate) %></div>
        
        <div class="display-label">Address</div>
        <div class="display-field"><%: Model.Address %></div>
        
        <div class="display-label">City</div>
        <div class="display-field"><%: Model.City %></div>
        
        <div class="display-label">Region</div>
        <div class="display-field"><%: Model.Region %></div>
        
        <div class="display-label">PostalCode</div>
        <div class="display-field"><%: Model.PostalCode %></div>
        
        <div class="display-label">Country</div>
        <div class="display-field"><%: Model.Country %></div>
        
        <div class="display-label">HomePhone</div>
        <div class="display-field"><%: Model.HomePhone %></div>

        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.EmployeeID }) %> |
        <%: Html.ActionLink("Back to Employee List", "Index") %>
    </p>

</asp:Content>

