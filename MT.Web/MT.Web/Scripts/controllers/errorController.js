angular.module('mtApp').controller('errorController', ['$scope', 'errorModel', 'errorService',
    function errorController($scope, errorModel, errorService) {
    errorService.showError($scope, errorModel.model);
}]);