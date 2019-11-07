define(function () {
    toastr.options.timeOut = 4000;
    toastr.options.positionClass = 'toast-bottom-right';


    var remoteServiceName = 'breeze/Breeze';

    return {
        debugEnabled: ko.observable(true),
        remoteServiceName: remoteServiceName
    };
});