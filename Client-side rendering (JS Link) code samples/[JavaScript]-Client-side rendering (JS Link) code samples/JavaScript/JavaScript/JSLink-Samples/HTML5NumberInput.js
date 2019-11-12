// List New and Edit Forms – HTML5 Number Input Sample
// Muawiyah Shannak , @MuShannak

(function () {

    // Create object that have the context information about the field that we want to change it's output render 
    var ageFiledContext = {};
    ageFiledContext.Templates = {};
    ageFiledContext.Templates.Fields = {
        // Apply the new rendering for Age field on New and Edit forms
        "Age": {
            "NewForm": ageFiledTemplate,
            "EditForm": ageFiledTemplate
        }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(ageFiledContext);

})();


// This function provides the rendering logic
function ageFiledTemplate(ctx) {

    var formCtx = SPClientTemplates.Utility.GetFormContextForCurrentField(ctx);

    // Register a callback just before submit.
    formCtx.registerGetValueCallback(formCtx.fieldName, function () {
        return document.getElementById('inpAge').value;
    });

    // Render Html5 input (number)
    return "<input type='number' id='inpAge' min='18' max='110' value='" + formCtx.fieldValue + "'/>";
}

