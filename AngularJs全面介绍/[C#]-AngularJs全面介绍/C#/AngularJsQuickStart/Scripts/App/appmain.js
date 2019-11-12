(function () {
    // 注入路由，注入提供数据的服务模块和Demo.Controllers模块
    var mainApp = angular.module("mainApp", ['ngRoute', 'Demo.Services', 'Demo.Controllers', "Demo.Directives","Demo.Filters"]);

    mainApp.controller("tempController", ["$scope", function ($scope) {
        $scope.val = "Welcome to Study AngularJs.";
    }]);

    mainApp.controller("cntoController", ["$scope", function ($scope) {
        var defaultValue = "Learninghard 前端系列";
        $scope.val = defaultValue;
        $scope.click = function () {
            $scope.val = defaultValue;
        };
    }]);

    // 有三种方法来创建服务。
    // 1.使用系统内置的$provide服务
    // 2.使用Module的factory方法
    // 3.使用Module的service方法

    // 工厂方式创建服务
    mainApp.factory('mathService', function () {
        var factory = {};
        factory.multiply = function (a, b) {
            return a * b;
        };
        return factory;
    });
    // 服务方式来创建服务
    mainApp.service('calcService', function (mathService) {
        this.square = function (a) {
            return mathService.multiply(a, a);
        };
    });

    // 注入calcService服务
    mainApp.controller('calcController', function ($scope, calcService) {
        $scope.square = function () {
            $scope.result = calcService.square($scope.number);
        };
    });

    mainApp.controller("dectController", ['$scope', 'service', function ($scope, service) {
        $scope.list = service();
    }]);

    // 
    mainApp.controller("filterController", ['$scope', function($scope) {
        $scope.greeting = "AngularJs";
    }]);
    
    mainApp.config(['$routeProvider', function ($routeProvider) {
        // 路由配置
        var route = $routeProvider;
        //指定URL为“/” 控制器：“listController”，模板：“route-list.html”
        route.when('/list', { controller: 'listController', templateUrl: 'route-list.html' });
        //注意“/view/:id” 中的 “：id” 用于捕获参数ID
        route.when('/view/:id', { controller: 'viewController', templateUrl: 'route-view.html' });
        //跳转
        route.when("/", { redirectTo: '/list' });
        route.otherwise({ redirectTo: '/list' });
    }]);
})();
