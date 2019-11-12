(function () {
    'use strict';

    angular
        .module('app.photo')
        .controller('photos', photos); 

    photos.$inject = ['photoManager'];

    function photos(photoManager) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'photo manager';
        vm.photos = photoManager.photos;
        vm.uploading = false;
        vm.previewPhoto;        
        vm.remove = photoManager.remove;
        vm.setPreviewPhoto = setPreviewPhoto;        

        activate();

        function activate() {
            photoManager.load();
        }

        function setPreviewPhoto(photo) {         
            vm.previewPhoto = photo         
        }

        function remove(photo) {
            photoManager.remove(photo).then(function () {
                setPreviewPhoto();
            });
        }
    }
})();
