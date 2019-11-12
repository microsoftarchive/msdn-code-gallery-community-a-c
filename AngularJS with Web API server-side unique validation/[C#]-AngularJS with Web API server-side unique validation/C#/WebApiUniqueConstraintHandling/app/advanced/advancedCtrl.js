(function () {
    'use strict';

    angular
        .module('app')
        .controller('advancedCtrl', advancedCtrl);

    advancedCtrl.$inject = ['$scope', '$q', 'bookClientSvc'];

    function advancedCtrl($scope, $q, bookClientSvc) {
        $scope.title = 'advanced validation';
        $scope.description = 'The book title has to be unique. When updating the title field a lookup is made to check whether the title already exists or not.';

        $scope.book = newBook();
        $scope.books = [];
        $scope.loadBooks = loadBooks;

        $scope.save = save;
        $scope.clear = clear;
        $scope.checkTitle = checkTitle;

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
        }

        function save() {
            if ($scope.newBookForm.$valid) {
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
                                                } else {
                                                    $scope.status.message = "something went wrong";
                                                }
                                            })
                                            ['finally'](function () {
                                                $scope.status.busy = false;
                                            });
            }
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

        function checkTitle(title) {
            if (title) {
                return $q(function (resolve, reject) {
                    bookClientSvc.titleAvailable({ title: title })
                                            .$promise
                                            .then(function (result) {
                                                if (result.titleAvailable) {
                                                    resolve(result);
                                                } else {
                                                    reject(result);
                                                }
                                            },
                                            function (result) {
                                                resolve("unexpected error");
                                            });
                });
            } else {
                return $q(function (resolve) {
                    resolve();
                });
            }
        }

        function newBook() {
            return {
                id: 0,
                title: '',
                author: ''
            };
        }
    }
})();
