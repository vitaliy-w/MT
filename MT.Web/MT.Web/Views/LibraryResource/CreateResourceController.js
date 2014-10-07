angular.module('mtApp').controller('createLibraryResourceController',
   function ($scope, validationService, createLibraryResourceService) {

       //Test data for emulation userId fields
       $scope.resource = { userId: 1 };

       // formName - form name for validation
       $scope.create = function (formName) {
           if (!validationService.isValid(formName))
               return;
           
           createLibraryResourceService.saveResource($scope.resource);
       };
   });

// Fabric method for saving LibraryResource instance using httpService
angular.module('mtApp').factory('createLibraryResourceService', function (httpService) {
    return {
        saveResource: function (resource) {
            return httpService.post('LibraryResource/Create', resource);
        }
    };
});