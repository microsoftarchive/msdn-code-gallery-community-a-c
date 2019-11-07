var app;
(function () {
    'use strict';
    app = angular.module('UIGrid_App',
        [
            'ngAnimate',                // support for CSS-based animations
            'ngTouch',                  //for touch-enabled devices
            'ui.grid',                  //data grid for AngularJS
            'ui.grid.pagination',       //data grid Pagination
            'ui.grid.resizeColumns',    //data grid Resize column
            'ui.grid.moveColumns',      //data grid Move column
            'ui.grid.pinning',          //data grid Pin column Left/Right
            'ui.grid.selection',        //data grid Select Rows
            'ui.grid.autoResize',       //data grid Enabled auto column Size
            'ui.grid.exporter'          //data grid Export Data
        ]);
})();