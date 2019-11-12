(function () {
    //创建一个 angularjs 过滤器模块
    var filter = angular.module("Demo.Filters", []);
    // 定义反转过滤器，过滤器用来格式化数据(转化，排序，筛选等操作)。
    filter.filter('reverse', function() {
        return function(input, uppercase) {
            input = input || '';
            var out = "";
            for (var i = 0; i < input.length; i++) {
                out = input.charAt(i) + out;
            }
            
            if (uppercase) {
                out = out.toUpperCase();
            }
            return out;
        };
    });
})();