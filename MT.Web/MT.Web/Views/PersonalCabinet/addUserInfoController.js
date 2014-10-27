    angular.module('mtApp').controller('addUserInfo',
function ($scope, validationService, addUserInfoService) {

    $scope.userInfo = {};
    $scope.userInfo.Name = "";
    $scope.userInfo.SecondName = "";
    $scope.userInfo.IsMan = false;
    $scope.userInfo.DateOfBirth = null;

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



    // formName - form name for validation
    $scope.create = function (formName) {


        if (!validationService.isValid(formName))
            return;
        $scope.messageFromServer = "";
        addUserInfoService.saveResource($scope, $scope.userInfo);

    };
});

// Fabric method for saving LibraryResource instance using httpService
angular.module('mtApp').factory('addUserInfoService', function (httpService) {
    return {
        saveResource: function (scope, resource) {
            return httpService.post('PersonalCabinet/Create', resource).then(function (responce) {

                if (responce.header == "Error") {

                    for (var i = 0; i < responce.errorMessagesList.length; i++) {

                        scope.messageFromServer += responce.errorMessagesList[i]+" ";
                    }


                    scope.isWarningVisible = true;
                }

                else {
                    scope.isSuccessVisible = true;
                    scope.messageFromServer = responce.data.message;
                }
            });
        }
    };
});
