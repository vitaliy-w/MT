angular.module('mtApp').controller('userEducationController',
   function ($scope, validationService, errorService, userEducationControllerService, modelFromServer) {

       $scope.UserEducationList = [];
       $scope.IsVisibleSection = [true, false, false];
       $scope.listForServer = [];
       

       var data = modelFromServer;
       
       $scope.showSecondSection = function (formName) {

           if (!validationService.isValid(formName))
               return;
           $scope.IsVisibleSection[1] = true;
           $scope.UserEducationList[1] = modelFromServer[1];
           $scope.UserEducationList[1].EducationId = 2;

       }

       $scope.showThirdSection = function (formName) {
           if (!validationService.isValid(formName))
               return;
           $scope.IsVisibleSection[2] = true;
           $scope.UserEducationList[2] = modelFromServer[2];
           $scope.UserEducationList[2].EducationId = 3;

       }

       if (data[1].NameOfSchool != '' && modelFromServer[1].NameOfSchool != null) $scope.showSecondSection('addUserEducation');
       if (data[2].NameOfSchool != '' && modelFromServer[2].NameOfSchool != null) $scope.showThirdSection('addUserEducation');



       $scope.UserEducationList[0] = modelFromServer[0];
       $scope.UserEducationList[0].EducationId = 1;

       $scope.showResult = function (responce) {
           $scope.isSuccessVisible = false;
           $scope.isSuccessVisible = false;
           if (responce.header == "Error") {
               errorService.showError($scope, responce.errorMessagesList);
           }

           else {
               $scope.isSuccessVisible = true;
               $scope.messageFromServer = responce.data.message;
           }
       };

       $scope.create = function (formName) {
           if (!validationService.isValid(formName))
               return;
           $scope.messageFromServer = "";

           var k = 0;
           for (var i = 0; i < $scope.IsVisibleSection.length; i++) {
               if ($scope.IsVisibleSection[i] == true) {
                   $scope.listForServer[k] = $scope.UserEducationList[i];
                   k++;
               }
           }
           userEducationControllerService.saveResource($scope, $scope.listForServer, $scope.showResult);
       };

   });

angular.module('mtApp').factory('userEducationControllerService', function (httpService) {
    return {
        saveResource: function (scope, resource, showResult) {
            return httpService.post('Education/AddUserEducation', resource).then(function (responce) {
                showResult(responce);
            });
        }


    };

});




