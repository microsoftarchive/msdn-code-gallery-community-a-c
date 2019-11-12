// List Forms – User CSRListForm Server Tempalte
// Muawiyah Shannak , @MuShannak 
 
(function () { 
 
    // Create object that have the context information about the field that we want to change it's output render  
    var formTemplate = {};
    formTemplate.Templates = {};
    formTemplate.Templates.View = viewTemplate;
 
    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(formTemplate);
 
})(); 
 
// This function provides the rendering logic for the Custom Form
function viewTemplate(ctx) {
    
    var formTable = "".concat("<table width='100%' cellpadding='5'>",
                                    "<tr>",
                                        "<td><div>Title</div></td>",
                                        "<td><div>{{TitleCtrl}}</div></td>",
                                        "<td><div>Date</div></td>",
                                        "<td><div>{{DateCtrl}}</div></td>",
                                    "</tr>",
                                    "<tr>",
                                        "<td><div>Category</div></td>",
                                            "<td><div>{{CategoryCtrl}}</div></td>",
                                        "<td><div>Active</div></td>",
                                        "<td><div>{{ActiveCtrl}}</div></td>",
                                    "</tr>",
                                    "<tr>",
                                        "<td></td>",
                                        "<td><input type='button' value='Save' onclick=\"SPClientForms.ClientFormManager.SubmitClientForm('{{FormId}}')\" style='margin-left:0' ></td>",
                                    "</tr>",
                              "</table>");

    
    //Replace the tokens with the default sharepoint controls
    formTable = formTable.replace("{{TitleCtrl}}", getSPFieldRender(ctx, "Title"));
    formTable = formTable.replace("{{DateCtrl}}", getSPFieldRender(ctx, "Date"));
    formTable = formTable.replace("{{CategoryCtrl}}", getSPFieldRender(ctx, "Category"));
    formTable = formTable.replace("{{ActiveCtrl}}", getSPFieldRender(ctx, "Active"));
    formTable = formTable.replace("{{FormId}}", ctx.FormUniqueId);

    return formTable;
}

//This function code set the required properties and call the OOTB (default) function that use to render Sharepoint Fields 
function getSPFieldRender(ctx, fieldName)
{
    var fieldContext = ctx;

    //Get the filed Schema
    var result = ctx.ListSchema.Field.filter(function( obj ) {
        return obj.Name == fieldName;
    });

    //Set the field Schema  & default value
    fieldContext.CurrentFieldSchema = result[0];
    fieldContext.CurrentFieldValue = ctx.ListData.Items[0][fieldName];

    //Call  OOTB field render function 
    return ctx.Templates.Fields[fieldName](fieldContext);
}
