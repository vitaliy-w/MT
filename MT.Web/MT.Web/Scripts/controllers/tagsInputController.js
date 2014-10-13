angular.module('mtApp').controller('tagsInputController', function ($scope, tagsInputService) {
    $scope.tags = [];

    $scope.loadTags = function (query) {
        return tagsInputService.load(query);
    };
});