angular.module('mtApp').controller('createLocalizationResource',
function ($scope, validationService, createLocalizationService) {

    $scope.resource = {};
    $scope.isSectionVisible = [false];  //array of sections that displays fields for new entry.
    $scope.isWarningVisible = false;
    $scope.isSuccessVisible = false;

    $scope.resource.LocalizedResources = [];  //Если явно не создавать массив, ангуляр его не будет биндить на вьюху.
    $scope.resource.ResourceCultureCodes = [];

   // formName - form name for validation
    $scope.create = function (formName) {

        $scope.isWarningVisible = false;
        $scope.isSuccessVisible = false;

        if (!validationService.isValid(formName))
            return;

        createLocalizationService.saveResource($scope, $scope.resource);
    };
});

// Fabric method for saving LibraryResource instance using httpService
angular.module('mtApp').factory('createLocalizationService', function (httpService) {
    return {
        saveResource: function (scope, resource) {
            return httpService.post('Management/Localization/Create', resource).then(function (responce) {

                if (responce.header == "Error") {
                    scope.isWarningVisible = true;
                }

                else {
                    scope.isSuccessVisible = true;
                }
                scope.messageFromServer = responce.errorMessagesList[0];
            });
        }
    };
});

