@ModelType IEnumerable(Of MvcRazorVB.UserModel)

@Code
    ViewBag.Title = "no Index"
    ViewBag.Title = " The Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

    <h2>Index</h2>

    <p>
        @Html.ActionLink("Create New", "Create")
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                UserName
            </th>
            <th>
                FirstName
            </th>
            <th>
                LastName
            </th>
            <th>
                City
            </th>
        </tr>

    @For Each item In Model
    
        @<tr>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.UserName}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.UserName}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.UserName})
            </td>
            <td>
                @item.UserName
            </td>
            <td>
                @item.FirstName
            </td>
            <td>
                @item.LastName
            </td>
            <td>
                @item.City
            </td>
        </tr>
    
    Next

    </table>


