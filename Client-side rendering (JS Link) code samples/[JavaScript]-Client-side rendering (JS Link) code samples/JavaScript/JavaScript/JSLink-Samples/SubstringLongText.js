// List View - Substring Long String Sample
// Muawiyah Shannak , @MuShannak

(function () {

    // Create object that have the context information about the field that we want to change it's output render 
    var bodyFiledContext = {};
    bodyFiledContext.Templates = {};
    bodyFiledContext.Templates.Fields = {
        // Apply the new rendering for Body field on list view
        "Body": { "View": bodyFiledTemplate }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(bodyFiledContext);

})();

// This function provides the rendering logic
function bodyFiledTemplate(ctx) {

    var bodyValue = ctx.CurrentItem[ctx.CurrentFieldSchema.Name];

    //This regex expression use to delete html tags from the Body field
    var regex = /(<([^>]+)>)/ig;

    bodyValue = bodyValue.replace(regex, "");

    var newBodyValue = bodyValue;

    if (bodyValue && bodyValue.length >= 100)
    {
        newBodyValue = bodyValue.substring(0, 100) + " ...";
    }

    return "<span title='" + bodyValue + "'>" + newBodyValue + "</span>";
       
}

