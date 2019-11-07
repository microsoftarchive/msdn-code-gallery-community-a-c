(function () {
    //创建一个 angularjs 服务模块
    var service = angular.module("Demo.Services",[]);

    //创建一个提供数据的服务器
    service.service("service", function () {
        var list = [
           { id: 1, title: "博客园", url: "http://www.cnblogs.com" },
           { id: 2, title: "知乎", url: "http://www.zhihu.com" },
           { id: 3, title: "codeproject", url: "http://www.codeproject.com/" },
           { id: 4, title: "stackoverflow", url: "http://www.stackoverflow.com/" }
        ];
        return function (id) {
            //假如ID为无效值返回所有
            if (!id) return list;
            var t = 0;
            //匹配返回的项目
            angular.forEach(list, function (v, i) {
                if (v.id == id) t = i;
            });
            return list[t];
        };
    });
})();