// List New and Edit Forms – Repeater Input Sample
// Muawiyah Shannak , @MuShannak

var repeaterFormArr = [
    "<input type='text' id='nameInput' placeholder='Full Name' required class='ms-long ms-spellcheck-true'>",
    "<input type='number' id='ageInput' placeholder='Age' required style='padding: 2px 4px;' class='ms-long ms-spellcheck-true'>",
    "<input type='text' id='ssnInput' placeholder='SSN' pattern=\"^\\d{3}-\\d{2}-\\d{4}$\" title='###-##-####' class='ms-long ms-spellcheck-true'>",
];

var ControlRenderMode;
var repeaterFormValues = [];

(function () {

    // Create object that have the context information about the field that we want to change it's output render 
    var repeaterFiledContext = {};
    repeaterFiledContext.Templates = {};
    repeaterFiledContext.Templates.Fields = {
        // Apply the new rendering for Age field on New and Edit forms
        "Dependents": {
            "View": RepeaterFiledViewTemplate,
            "DisplayForm": RepeaterFiledViewTemplate,
            "NewForm": RepeaterFiledEditFTemplate,
            "EditForm": RepeaterFiledEditFTemplate
        }
    };

    SPClientTemplates.TemplateManager.RegisterTemplateOverrides(repeaterFiledContext);

})();


// This function provides the rendering logic
function RepeaterFiledViewTemplate(ctx) {

    ControlRenderMode = ctx.ControlMode;

    if (ctx.CurrentItem[ctx.CurrentFieldSchema.Name] && ctx.CurrentItem[ctx.CurrentFieldSchema.Name] != '[]') {
        var fieldValue = ctx.CurrentItem[ctx.CurrentFieldSchema.Name].replace(/&quot;/g, "\"").replace(/(<([^>]+)>)/g, "");
        repeaterFormValues = JSON.parse(fieldValue);
    }

    return GetRenderHtmlRepeaterValues();
}
// This function provides the rendering logic
function RepeaterFiledEditFTemplate(ctx) {

    ControlRenderMode = ctx.ControlMode;

    var formCtx = SPClientTemplates.Utility.GetFormContextForCurrentField(ctx);

    if (formCtx.fieldValue) {
        repeaterFormValues = JSON.parse(formCtx.fieldValue);
    }

    // Register a callback just before submit.
    formCtx.registerGetValueCallback(formCtx.fieldName, function () {
        return JSON.stringify(repeaterFormValues);
    });

    var index;
    var HTMLViewTemplate = "<form id='innerForm' onsubmit='return AddItem();'>{Controls}<div><input type='submit' value='Add' style='margin-left:0'></div><br/><div id='divRepeaterValues'>{RepeaterValues}</div><br/></form>";
    var returnHTML = "";

    for (index = 0; index < repeaterFormArr.length; ++index) {
        returnHTML += repeaterFormArr[index];
    }

    returnHTML = HTMLViewTemplate.replace(/{Controls}/g, returnHTML);
    returnHTML = returnHTML.replace(/{RepeaterValues}/g, GetRenderHtmlRepeaterValues());

    return returnHTML;
}

function GetRenderHtmlRepeaterValues() {

    var index;
    var innerindex;
    var HTMLItemsTemplate = "<table width='100%' style='border:1px solid #ababab;'>{Items}</table>";
    var HTMLItemTemplate = "<tr>{Item}</tr>";
    var HTMLValueTemplate = "<td>{Value}</td>";

    if (ControlRenderMode == SPClientTemplates.ClientControlMode.EditForm || ControlRenderMode == SPClientTemplates.ClientControlMode.NewForm) {
        HTMLItemTemplate = "<tr>{Item}<td><a href='javascript:DeleteItem({Index});'>Delete</a></td></tr>";
    }

    var returnHTML = "";
    var tempValueHtml;


    for (index = 0; index < repeaterFormValues.length; ++index) {
        tempValueHtml = "";

        for (innerindex = 0; innerindex < repeaterFormValues[index].length; ++innerindex) {
            tempValueHtml += HTMLValueTemplate.replace(/{Value}/g, repeaterFormValues[index][innerindex]["Value"]);
        }

        returnHTML += HTMLItemTemplate.replace(/{Item}/g, tempValueHtml);
        returnHTML = returnHTML.replace(/{Index}/g, index);
    }

    if (repeaterFormValues.length) {
        returnHTML = HTMLItemsTemplate.replace(/{Items}/g, returnHTML);
    }

    return returnHTML;
}

function AddItem() {

    var innerForm = document.getElementById('innerForm');

    if (innerForm.checkValidity()) {

        var index;
        var tempRepeaterValue = [];

        for (index = 0; index < innerForm.length; index++) {

            if (innerForm[index].type != "submit" && innerForm[index].type != "button" && innerForm[index].type != "reset") {
                tempRepeaterValue.push(
                   {
                       "ID": innerForm[index].id,
                       "Value": innerForm[index].value
                   }
                   );

                innerForm[index].value = "";
            }
        }


        repeaterFormValues.push(tempRepeaterValue);

        document.getElementById("divRepeaterValues").innerHTML = GetRenderHtmlRepeaterValues();
    }
    return false;
}

function DeleteItem(index) {
    repeaterFormValues.splice(index, 1);
    document.getElementById("divRepeaterValues").innerHTML = GetRenderHtmlRepeaterValues();
}

