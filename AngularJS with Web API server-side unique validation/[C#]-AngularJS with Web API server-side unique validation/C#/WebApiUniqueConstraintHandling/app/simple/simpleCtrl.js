(function () {
    'use strict';

    angular
        .module('app')
        .controller('simpleCtrl', simpleCtrl);

    simpleCtrl.$inject = ['$scope', 'bookClientSvc'];

    function simpleCtrl($scope, bookClientSvc) {
        $scope.title = 'simple validation';
        $scope.description = 'The book title has to be unique. When saving a new record if another book with the same title exists BookController will return an error. This is then handled and the problem reported to the user.';

        $scope.book = newBook();
        $scope.books = [];
        $scope.loadBooks = loadBooks;

        $scope.save = save;
        $scope.clear = clear;
        $scope.resetTitle = resetTitle;
        
        $scope.status = {
            type: "info",
            message: "ready",
            busy: true
        };        
        
        activate();

        function activate() {
            loadBooks();          
        }

        function clear() {
            $scope.book = newBook();
            $scope.newBookForm.$setPristine();
            $scope.newBookForm.$setUntouched();
            resetTitle();
        }

        function save() {   
            $scope.status.busy = true;
            $scope.status.message = "saving book";

            bookClientSvc.save($scope.book).$promise
                                        .then(function (result) {
                                            $scope.status.message = "ready";
                                            $scope.books.push($scope.book);
                                            clear();
                                        },
                                        function (result) {
                                            if (result.data && result.data.message.indexOf("Cannot insert duplicate key row in object 'dbo.Books' with unique index 'IX_Title'") > -1) {
                                                $scope.status.message = "a book with that title already exists";
                                                $scope.newBookForm.title.$setValidity("unique", false);
                                            } else {
                                                $scope.status.message = "something went wrong";
                                            }
                                        })
                                        ['finally'](function () {
                                            $scope.status.busy = false;
                                        });   
        }

        function loadBooks() {
            $scope.status.busy = true;
            $scope.status.message = "loading records";

            bookClientSvc.query().$promise
                                .then(function (result) {
                                    result.forEach(function (book) {
                                        $scope.books.push(book);                                        
                                    });
                                    $scope.status.message = "ready";
                                },                                    
                                function (result) {
                                    $scope.status.message = "something went wrong";
                                })
                                ['finally'](function () {
                                    $scope.status.busy = false;
                                });
        }

        function resetTitle() {
            $scope.newBookForm.title.$setValidity("unique", true);
        }

        function newBook(){
            return {
                id:0,
                title: '',
                author: ''
            };
        }
    }
})();
