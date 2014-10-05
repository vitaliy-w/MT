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
                userName: $scope.userName,
                email: $scope.email,
                password: $scope.password,
                confirmPassword: $scope.confirmPassword
            });
        };

    });


// ������� ������� ��� �������� �������� �� ������ ��� ���������� �����.
// ���������� ������ httpService ��� ������� � ��������� ��������.
angular.module('mtApp').factory('registerService', function (httpService) {
    return {
        // � ������� ��������� ������ 1 ����� - ���������� ������������.
        saveUser: function (user) {
            // �������� ���� � ����� Create ����������� Test �� c����� � ������� � ����� � ���� ������� ������ �������� �� Test/Index
            return httpService.postWithRedirect('Account/Register', user, 'Test/Index');

        }
    };
});