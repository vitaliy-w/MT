angular.module('mtApp').controller('createLocalizationResource',
function ($scope, validationService, createLocalizationService) {

    $scope.resource = {};
    $scope.isSectionVisible = [false];
    $scope.resource.LocalizedResources = [];  //Немного уличной магии. Если не создавать массив явно, не сработает dataBinding в контроллере.
    $scope.resource.ResourceCultureCodes = [];

    // formName - form name for validation
    $scope.create = function (formName) {
        if (!validationService.isValid(formName))
            return;
        createLocalizationService.saveResource($scope.resource);

    };
});

// Fabric method for saving LibraryResource instance using httpService
angular.module('mtApp').factory('createLocalizationService', function (httpService) {
    return {
        saveResource: function (resource) {
            return httpService.post('Management/Localization/Create', resource).then(function (responce) {
                var x = document.getElementById("msg_from_server");
                x.innerHTML = responce;
            });
        }
    };
});

