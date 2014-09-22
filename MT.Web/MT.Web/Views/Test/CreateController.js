angular.module('mtApp').controller('createTestController',
    function ($scope, validationService) {

        $scope.create = function (formName) {
            if (!validationService.isValid(formName))
                return;
           
        };

     
        $scope.test = "test";
       
    });


angular.module('mtApp').factory('createTestService', function (httpService) {
    return {
        saveUser: function (user) {
            return httpService.post('Test/Create', user);
        }
    };
});