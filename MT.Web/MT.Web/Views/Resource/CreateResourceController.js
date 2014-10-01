angular.module('mtApp').controller('createResourceController',
   function ($scope, validationService, createResourceService) {

       //Test data for emulation userId fields
       $scope.resource = { userId: 1};
       
       $scope.create = function (formName) {
           if (!validationService.isValid(formName))
               return;
           
           createResourceService.saveResource($scope.resource);
       };
   });


angular.module('mtApp').factory('createResourceService', function (httpService) {
    return {
        saveResource: function (resource) {
            return httpService.post('Resource/Create', resource);
        }
    };
});