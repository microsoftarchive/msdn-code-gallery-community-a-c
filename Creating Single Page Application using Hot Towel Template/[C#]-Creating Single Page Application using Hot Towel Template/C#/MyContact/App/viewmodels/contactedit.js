define(['services/logger', 'services/datacontext', 'plugins/router', 'plugins/dialog'], function (logger, datacontext, router, app) {
    var contact = ko.observable();
    var title = 'Edit Contact';
    var isSaving = ko.observable(false);

    //Cancel Command
    var cancel = function (complete) {
        router.navigateBack();
    };


    var hasChanges = ko.computed(function () {

        return datacontext.hasChanges();
    });



    //Activate method will call while page loading
    function activate(routeData) {

        if (!(routeData.toString() === ':id')) {

            datacontext.getAContactDetail(routeData, contact);
        }
        else {

            datacontext.createContact(contact);
        }


    }


    //Deactivate method will call while page unloading
    var deactivate = function () {

    };

    //Save command
    var save = function () {
        isSaving(true);
        datacontext.saveChanges()
            .then(goToEditView).fin(complete);

        function goToEditView(result) {
            router.navigate('');
        }

        function complete() {
            isSaving(false);
        }
    };
    var canSave = ko.computed(function () {

        return hasChanges() && !isSaving();
    });

    //This method will call and get confirmation from user while page redirecting.
    var canDeactivate = function () {
        if (hasChanges()) {
            var msg = 'Do you want to leave and cancel?';
            return app.showMessage(msg, title, ['Yes', 'No'])
                .then(function (selectedOption) {
                    if (selectedOption === 'Yes') {
                        datacontext.cancelChanges();

                    }
                    return selectedOption;
                });
        }
        return true;
    }

    //ViewModel Properties, Method and Command object
    var vm = {
        activate: activate,
        canDeactivate: canDeactivate,
        deactivate: deactivate,
        contact: contact,
        title: title,
        canSave: canSave,
        cancel: cancel,
        hasChanges: hasChanges,
        save: save
    };

    return vm;
});