angular.module('mtApp').controller('createResourceController',
   function ($scope, validationService, createResourceService) {

       //Test data for emulation userId fields
       $scope.resource = { userId: 1 };

       // formName - form name for validation
       $scope.create = function (formName) {
           if (!validationService.isValid(formName))
               return;
           
           createResourceService.saveResource($scope.resource);
       };
   });

// Fabric method for saving Resource instance using httpService
angular.module('mtApp').factory('createResourceService', function (httpService) {
    return {
        saveResource: function (resource) {
            return httpService.post('Resource/Create', resource);
        }
    };
});