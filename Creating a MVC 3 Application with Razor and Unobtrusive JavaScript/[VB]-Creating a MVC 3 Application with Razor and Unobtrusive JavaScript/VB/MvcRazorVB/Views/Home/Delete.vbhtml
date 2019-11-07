@ModelType MvcRazorVB.UserModel

@Code
    ViewBag.Title = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
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
    @Using Html.BeginForm()
        @<p>
            <input type="submit" value="Delete" /> |
            @Html.ActionLink("Back to List", "Index")
        </p>
    End Using


