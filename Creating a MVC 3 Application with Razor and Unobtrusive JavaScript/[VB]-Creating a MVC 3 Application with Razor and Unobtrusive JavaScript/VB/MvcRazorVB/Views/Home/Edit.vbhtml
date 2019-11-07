@ModelType MvcRazorVB.UserModel

@Code
    ViewBag.Title = "Edit"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

    <h2>Edit</h2>

    @Using Html.BeginForm()
	@Html.Hidden("UserName", Model.UserName)
        @Html.ValidationSummary(True)
        @<fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                @Html.LabelFor(Function(model) model.UserName)
            </div>
            <div class="editor-field">
                @Html.DisplayFor(Function(model) model.UserName)

            </div>
            
            <div class="editor-label">
                @Html.LabelFor(Function(model) model.FirstName)
            </div>
            <div class="editor-field">
                @Html.TextBoxFor(Function(model) model.FirstName)
                @Html.ValidationMessageFor(Function(model) model.FirstName)
            </div>
            
            <div class="editor-label">
                @Html.LabelFor(Function(model) model.LastName)
            </div>
            <div class="editor-field">
                @Html.TextBoxFor(Function(model) model.LastName)
                @Html.ValidationMessageFor(Function(model) model.LastName)
            </div>
            
            <div class="editor-label">
                @Html.LabelFor(Function(model) model.City)
            </div>
            <div class="editor-field">
                @Html.TextBoxFor(Function(model) model.City)
                @Html.ValidationMessageFor(Function(model) model.City)
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    End Using

    <div>
        @Html.ActionLink("Back to List", "Index")
    </div>


