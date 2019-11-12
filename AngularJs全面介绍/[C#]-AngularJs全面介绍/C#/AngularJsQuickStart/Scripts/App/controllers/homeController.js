(function () {
    // 创建Demo.Controllers模块
    var listController = angular.module("Demo.Controllers", []);

    //创建控制器 listController,注入提供数据服务
    listController.controller("listController", ["$scope", "service", function ($scope, service) {
        //获取所有数据
        $scope.list = service();
    }]);

    //创建查看控制器 viewController, 注意应为需要获取URL ID参数 我们多设置了一个 依赖注入参数 “$routeParams” 通过它获取传入的 ID参数
    listController.controller("viewController", ["$scope", "service", '$routeParams', function ($scope, service, $routeParams) {
        $scope.model = service($routeParams.id || 0) || {};
    }]);
})();