// List view – Confidential Documents Sample
// Muawiyah Shannak , @MuShannak

(function () {

    // Create object that have the context information about the field that we want to change it's output render 
    var linkFilenameFiledContext = {};
    linkFilenameFiledContext.Templates = {};
    linkFilenameFiledContext.Templates.Fields = {
        // Apply the new rendering for LinkFilename field on list view
        "LinkFilename": { "View": linkFilenameFiledTemplate }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(linkFilenameFiledContext);

})();

// This function provides the rendering logic
function linkFilenameFiledTemplate(ctx) {

    var confidential = ctx.CurrentItem["Confidential"];
    var title = ctx.CurrentItem["FileLeafRef"];

    // This Regex expression use to delete extension (.docx, .pdf ...) form the file name
    title = title.replace(/\.[^/.]+$/, "")

    // Check confidential field value
    if (confidential && confidential.toLowerCase() == 'yes') {
        
        // Render HTML that contains the file name and the confidential icon
        return title + "&nbsp;<img src='/Style%20Library/JSLink-Samples/imgs/Confidential.png' alt='Confidential Document' title='Confidential Document'/>";
    }
    else
    {
        return title;
    }
}

