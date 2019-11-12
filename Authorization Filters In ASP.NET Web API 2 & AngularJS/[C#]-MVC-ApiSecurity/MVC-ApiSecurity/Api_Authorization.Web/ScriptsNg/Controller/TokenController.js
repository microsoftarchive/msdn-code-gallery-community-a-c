
AppSecurity.controller('tokenCtrl', ['$scope', '$http', 'crudService', '$sessionStorage',
function ($scope, $http, crudService, $sessionStorage) {

    //Token Generate ClientEnd
    $scope.tokenManager = {
        generateSecurityToken: function (methodtype) {
            var model = {
                username: $sessionStorage.loggeduser,
                key: methodtype,
                ip: $sessionStorage.loggedip,
                userAgent: navigator.userAgent.replace(/ \.NET.+;/, '')
            };

            var message = [model.username, model.ip, model.userAgent].join(':');
            var hash = CryptoJS.HmacSHA256(message, model.key);

            var token = CryptoJS.enc.Base64.stringify(hash);
            var tokenId = [model.username, model.key].join(':');
            var tokenGenerated = CryptoJS.enc.Utf8.parse([token, tokenId].join(':'));

            return CryptoJS.enc.Base64.stringify(tokenGenerated);
        },
    };
}]);