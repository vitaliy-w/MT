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
    function (httpService) {
        return {
            userLogin: function ($scope, user, returnUrl) {
                return httpService.post('Account/Login', user).then(
                    function(message) {
                        $scope.message = message;
                        if ($scope.message.status) window.location = returnUrl;
                    }
                );
            }
        };
    });