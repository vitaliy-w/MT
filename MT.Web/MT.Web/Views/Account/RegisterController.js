// 
angular.module('mtApp').controller('registerController',
    function ($scope, validationService, registerService) {
        // formName - им€ формы дл€ валидации.

        $scope.create = function (formName) {
            if (!validationService.isValid(formName))
                return;
            // ¬ызываем метод сервиса работы с запросамы к серверу и передаем ему данные о юзере.
            // $scope в данном варианте содержит необходимое поле userName, которое принимает модель в параметре екшена.
            registerService.saveUser({
                email: $scope.email,
                password: $scope.password,
                confirmPassword: $scope.confirmPassword
            });
        };

    });


// —оздаем фабрику дл€ передачи запросов на сервер дл€ сохранени€ юзера.
// »спользует сервис httpService дл€ общени€ с серверной стороной.
angular.module('mtApp').factory('registerService', function (httpService) {
    return {
        // ¬ фабрике описываем только 1 метод - сохранение пользовател€.
        saveUser: function (user) {
            // пост запрос с редиректом на '/Account/Index'
            return httpService.post('Account/Register', user).then(function () {
                window.location = window.location.origin + '/Account/Index';
            });
        }
    };
});