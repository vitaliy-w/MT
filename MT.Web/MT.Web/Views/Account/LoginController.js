angular.module('mtApp').controller('loginController',
   function ($scope, validationService, loginService) {
       $scope.message = {};
       $scope.login = function (formName) {
           if (!validationService.isValid(formName))
               return;
           loginService.userLogin($scope, $scope.user, $scope.returnUrl);
       };
   });


angular.module('mtApp').factory('loginService',
    function (httpService, errorService) {
        return {
            userLogin: function ($scope, user, returnUrl) {
                return httpService.post('Account/Login', user).then(
                    function(message) {
                        if (message.status) window.location = returnUrl;
                        errorService.showError($scope, message.text);
                    }
                );
            }
        };
    });