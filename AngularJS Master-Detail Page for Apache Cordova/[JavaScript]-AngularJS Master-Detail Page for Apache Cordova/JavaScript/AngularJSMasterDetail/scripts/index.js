// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkID=397704
// To debug code on page load in Ripple or on Android devices/emulators: launch your app, set breakpoints, 
// and then run "window.location.reload()" in the JavaScript Console.
(function () {
    "use strict";

    document.addEventListener( 'deviceready', onDeviceReady.bind( this ), false );

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener( 'pause', onPause.bind( this ), false );
        document.addEventListener( 'resume', onResume.bind( this ), false );
        
        // TODO: Cordova has been loaded. Perform any initialization that requires Cordova here.

        window.onresize = resizeListIOS.bind(this, false);
        resizeListIOS();
    };

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
    };

    function resizeListIOS() {

        var width = isNaN(window.innerWidth) ? window.clientWidth : window.innerWidth;
        var height = isNaN(window.innerHeight) ? window.clientHeight : window.innerHeight;

        var elem = document.querySelector(".main-list");

        if (isVHPartiallySupported == true) {
            // landscape
            if (width > height) {
                elem.style.height = (Math.round(height * .9)) + "px";
            }
            // portrait
            else {
                elem.style.height = (Math.round(height * .15)) + "px";
            }
        }
    }

} )();