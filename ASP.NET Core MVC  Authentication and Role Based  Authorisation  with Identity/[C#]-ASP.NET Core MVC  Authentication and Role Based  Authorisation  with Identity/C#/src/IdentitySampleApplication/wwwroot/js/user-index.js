(function ($) {
    function User() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-user").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new User();
        self.init();
    })
}(jQuery))