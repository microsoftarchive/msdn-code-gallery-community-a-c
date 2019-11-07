(function ($) {

    function AddUser(){
        var $this = this;

        function initilizeUser() {
            var formAddUser = new Global.FormHelper($("#frm-add-user form"), { updateTargetId: "validation-summary" })
        }

        $this.init = function () {
            initilizeUser();
        }
    }
    $(function () {
        var self = new AddUser();
        self.init();
    })

}(jQuery))