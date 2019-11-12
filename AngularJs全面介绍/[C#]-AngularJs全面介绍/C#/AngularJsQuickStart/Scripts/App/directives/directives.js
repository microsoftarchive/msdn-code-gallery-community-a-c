(function () {
    var app = angular.module("Demo.Directives", []);

    app.directive('imCheck', [function () {
        return {
            restrict: 'A',
            replace: false,
            link: function (scope, element) {
                var all = "thead input[type='checkbox']";
                var item = "tbody input[type='checkbox']";
                //当点击选择所有项目
                element.on("change", all, function () {
                    var o = $(this).prop("checked");
                    var tds = element.find(item);
                    tds.each(function (i, check) {
                        $(check).prop("checked", o);
                    });
                });
                //子项修改时的超值
                element.on("change", item, function () {
                    var o = $(this).prop("checked");
                    var isChecked = true;
                    if (o) {
                        element.find(item).each(function () {
                            if (!$(this).prop("checked")) {
                                isChecked = false;
                                return false;
                            }
                            return true;
                        });
                    }
                    element.find(all).prop("checked", o && isChecked);
                });
            }
        };
    }]);
})();