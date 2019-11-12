@ModelType MvcRazorVB.UserModel

@Code
    ViewBag.Title = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">UserName</div>
        <div class="display-field">@Model.UserName</div>
        
        <div class="display-label">FirstName</div>
        <div class="display-field">@Model.FirstName</div>
        
        <div class="display-label">LastName</div>
        <div class="display-field">@Model.LastName</div>
        
        <div class="display-label">City</div>
        <div class="display-field">@Model.City</div>
        
    </fieldset>
    <p>
        @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.PrimaryKey}) |*@
        @Html.ActionLink("Back to List", "Index")
    </p>

