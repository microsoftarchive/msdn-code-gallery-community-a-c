// List New and Edit Forms – Disable Input Control Sample
// Muawiyah Shannak , @MuShannak

(function () {

    // Create object that have the context information about the field that we want to change it's output render 
    var disableFiledContext = {};
    disableFiledContext.Templates = {};
    disableFiledContext.Templates.Fields = {
        // Apply the new rendering for the field on New and Edit forms
        "Age": {
            "EditForm": disableFiledTemplate
        }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(disableFiledContext);

})();


// This function provides the rendering logic
function disableFiledTemplate(ctx) {

    var formCtx = SPClientTemplates.Utility.GetFormContextForCurrentField(ctx);
}

