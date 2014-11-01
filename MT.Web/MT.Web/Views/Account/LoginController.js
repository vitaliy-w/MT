angular.module('mtApp').controller('loginController',
   function ($scope, validationService, loginService) {

       $scope.redirectToUrl = function (returnUrl) {
           var search = window.location.search;
           var params = search.split("?")[1].split("&");
           for (var i = 0; i < params.length; i++) {
               var currPar = params[i].split("=");
               if (currPar[0].toLowerCase == returnUrl.toLowerCase) window.location = decodeURIComponent(currPar[1]);
           }
       };

       $scope.login = function (formName) {
           if (!validationService.isValid(formName))
               return;
           loginService.userLogin($scope, $scope.user).then(function(message) {
               if (message.login) {
                   $scope.redirectToUrl("ReturnUrl");
               }
           });
       };
   });


angular.module('mtApp').factory('loginService',
    function (httpService, errorService) {
        return {
            userLogin: function ($scope, user) {
                return httpService.post('Account/Login', user).then(
                    function (message) {
                        errorService.showError($scope, message.message);
                        return message;
                    }
                );
            }
        };
    });