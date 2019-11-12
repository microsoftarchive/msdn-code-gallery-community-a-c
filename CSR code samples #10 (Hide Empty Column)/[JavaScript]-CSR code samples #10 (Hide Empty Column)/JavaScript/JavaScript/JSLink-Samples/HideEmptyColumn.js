// List View – Hide Empty Column Sample
// Muawiyah Shannak , @MuShannak


(function () {

    // Create object that have the context information about the field that we want to change it's output render 
    var linkFiledContext = {};
    linkFiledContext.Templates = {};
   
    // Add OnPostRender event handler to hide the column if empty
    linkFiledContext.OnPostRender = linkOnPostRender;

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(linkFiledContext);

})();


function linkOnPostRender(ctx)
{
    var linkCloumnIsEmpty = 1;

    for (i = 0; i < ctx.ListData.Row.length; i++) {
        if (ctx.ListData.Row[i]["Link"])
        {
            linkCloumnIsEmpty = 0;
            break;
        }
    }

    //Hide "Link" column if it is empty
    if (linkCloumnIsEmpty) {
        var cell = $("div [name='Link']").closest('th');
        var cellIndex = cell[0].cellIndex + 1;

        $('td:nth-child(' + cellIndex + ')').hide();
        $('th:nth-child(' + cellIndex + ')').hide();
    }


}

