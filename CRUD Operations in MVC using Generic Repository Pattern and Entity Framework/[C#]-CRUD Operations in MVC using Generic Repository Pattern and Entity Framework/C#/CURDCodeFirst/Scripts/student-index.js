(function ($) {
    function Student() {
        var $this = this;

        function initilizeModel() {
            console.log('text2');
            $("#modal-action-student").on('loaded.bs.modal', function (e) {
                console.log('text1');
                }).on('hidden.bs.modal', function (e) {
                    console.log('text');
                    $(this).removeData('bs.modal');
                });            
        }       
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new Student();
        self.init();
        
    })
}(jQuery))
