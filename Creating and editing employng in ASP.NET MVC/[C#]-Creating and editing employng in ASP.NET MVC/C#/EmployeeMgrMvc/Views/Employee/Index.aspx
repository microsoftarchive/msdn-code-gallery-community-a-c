<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<EmployeeMgrMvc.Models.Employee>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Employee List</h2>

    <table>
        <tr>
            <th></th>
            <th>
                EmployeeID
            </th>
            <th>
                LastName
            </th>
            <th>
                FirstName
            </th>
            <th>
                HomePhone
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.EmployeeID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.EmployeeID })%> |
            </td>
            <td>
                <%: item.EmployeeID %>
            </td>
            <td>
                <%: item.LastName %>
            </td>
            <td>
                <%: item.FirstName %>
            </td>
            <td>
                <%: item.HomePhone %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

