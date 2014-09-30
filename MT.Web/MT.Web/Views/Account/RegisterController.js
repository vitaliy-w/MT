// 
angular.module('mtApp').controller('registerController',
    function ($scope, validationService, registerService) {
        // formName - имя формы для валидации.

        $scope.create = function (formName) {
            if (!validationService.isValid(formName))
                return;
            // Вызываем метод сервиса работы с запросамы к серверу и передаем ему данные о юзере.
            // $scope в данном варианте содержит необходимое поле userName, которое принимает модель в параметре екшена.
            registerService.saveUser({
                userName: $scope.userName,
                email: $scope.email,
                password: $scope.password,
                confirmPassword: $scope.confirmPassword
            });
        };

    });


// Создаем фабрику для передачи запросов на сервер для сохранения юзера.
// Использует сервис httpService для общения с серверной стороной.
angular.module('mtApp').factory('registerService', function (httpService) {
    return {
        // В фабрике описываем только 1 метод - сохранение пользователя.
        saveUser: function (user) {
            // Посылаем пост в екшен Create контроллера Test на cервер с данными о юзере.
            return httpService.post('Account/Register', user);

        }
    };
});