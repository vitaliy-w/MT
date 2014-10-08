// 
angular.module('mtApp').controller('registerController',
    function ($scope, validationService, registerService) {
        // formName - ��� ����� ��� ���������.

        $scope.create = function (formName) {
            if (!validationService.isValid(formName))
                return;
            // �������� ����� ������� ������ � ��������� � ������� � �������� ��� ������ � �����.
            // $scope � ������ �������� �������� ����������� ���� userName, ������� ��������� ������ � ��������� ������.
            registerService.saveUser({
                email: $scope.email,
                password: $scope.password,
                confirmPassword: $scope.confirmPassword
            });
        };
     
    });


// ������� ������� ��� �������� �������� �� ������ ��� ���������� �����.
// ���������� ������ httpService ��� ������� � ��������� ��������.
angular.module('mtApp').factory('registerService',  function (httpService) {
    return {
        // � ������� ��������� ������ 1 ����� - ���������� ������������.
        saveUser: function (user) {
            // ���� ������ � ���������� �� '/Account/Index'
            return httpService.post('Account/Register', user).then(function() {
                window.location = window.location.origin + '/Account/Index';
            });
        }

    };
});

