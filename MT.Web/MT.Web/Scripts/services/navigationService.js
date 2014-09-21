angular.module('mtApp').factory('navigationService', ['navigationModel', function (navigationModel) {
    return {
        redirect: function (url) {
            window.location.href = url;
        }
    };
}]);