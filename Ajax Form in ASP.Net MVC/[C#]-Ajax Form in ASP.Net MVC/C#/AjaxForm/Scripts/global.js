var Global = {};
Global.FormHelper = function (formElement, options, onSucccess, onError) {    
    var settings = {};
    settings = $.extend({}, settings, options);

    formElement.validate(settings.validateSettings);
    formElement.submit(function (e) {      
        if (formElement.valid()) {
            $.ajax(formElement.attr("action"), {
                type: "POST",
                data: formElement.serializeArray(),
                success: function (result) {
                    if (onSucccess === null || onSucccess === undefined) {
                        if (result.isSuccess) {
                            window.location.href = result.redirectUrl;
                        } else {
                            if (settings.updateTargetId) {
                                $("#" + settings.updateTargetId).html(result.data);
                            }
                        }
                    } else {
                        onSucccess(result);
                    }
                },
                error: function (jqXHR, status, error) {
                    if (onError !== null && onError !== undefined) {
                        onError(jqXHR, status, error);
                        $("#" + settings.updateTargetId).html(error);                       
                    }
                },
                complete: function () {
                }
            });
        }
        e.preventDefault();
    });

    return formElement;
};