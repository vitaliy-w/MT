angular.module('mtApp').controller('loginController',
   function ($scope, validationService, loginService, queryStringDataProvider) {

       $scope.login = function (formName) {
           if (!validationService.isValid(formName))
               return;
           loginService.userLogin($scope, $scope.user).then(function (message) {
               if (message.isLogedIn) {
                   var paramValue = queryStringDataProvider.getParamValue("ReturnUrl");
                   if (paramValue) window.location = paramValue ;
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

angular.module('mtApp').factory('queryStringDataProvider',
    function () {
        return {
            getParamValue: function (queryStringParameter) {
                var search = window.location.search;
                var params = search.split("?")[1].split("&");
                for (var i = 0; i < params.length; i++) {
                    var currPar = params[i].split("=");
                    if (currPar[0].toLowerCase == queryStringParameter.toLowerCase)
                        return decodeURIComponent(currPar[1]);
                }
            }
        };
    }
);