angular.module('mtApp').controller('createResourceController',
   function ($scope, validationService, createResourceService) {

       $scope.create = function (formName) {
           if (!validationService.isValid(formName))
               return;
           createResourceService.saveResource({ Name: $scope.Name, Access: $scope.Access, Link: $scope.Link, Description: $scope.Description, UserId: 1, User: { Id: 1, UserName: "Test" } });
       };
   });


angular.module('mtApp').factory('createResourceService', function (httpService) {
    return {
        saveResource: function (resource) {
            return httpService.post('Resource/Create', resource);
        }
    };
});