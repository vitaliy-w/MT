angular.module('mtApp').controller('privateInfoController',
function ($scope, validationService, privateInfoControllerService) {

    $scope.userInfo = {};
    $scope.userInfo.Name = "";
    $scope.userInfo.SecondName = "";
    $scope.userInfo.IsMan = false;
    $scope.userInfo.DateOfBirth = null;
    $scope.userInfo.UTCZone = null;


    $scope.today = function () {
        $scope.userInfo.DateOfBirth = new Date();
    };
    $scope.today();


    $scope.open = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
    };

    $scope.dateOptions = {
        formatYear: 'yy',
        startingDay: 1
    };

    $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    $scope.format = $scope.formats[0];

    $scope.showResult = function (responce) {
        if (responce.header == "Error") {

            for (var i = 0; i < responce.errorMessagesList.length; i++) {

                $scope.messageFromServer += responce.errorMessagesList[i] + " ";
            }


            $scope.isWarningVisible = true;
        }

        else {
            $scope.isSuccessVisible = true;
            $scope.messageFromServer = responce.data.message;
        }
    };

    // formName - form name for validation
    $scope.create = function (formName) {


        if (!validationService.isValid(formName))
            return;
        $scope.messageFromServer = "";

        privateInfoControllerService.saveResource($scope, $scope.userInfo, $scope.showResult);
    };
});

// Fabric method for saving LibraryResource instance using httpService
angular.module('mtApp').factory('privateInfoControllerService', function (httpService) {
    return {
        saveResource: function (scope, resource, showResult) {
            return httpService.post('PersonalCabinet/Create', resource).then(function (responce) {

                showResult(responce);

              
            });
        }


    };

});
