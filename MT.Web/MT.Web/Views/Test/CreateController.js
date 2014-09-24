// Создаем контролер angular - createTestController в наешм апликейшене mtApp.
// 
angular.module('mtApp').controller('createTestController',
    function ($scope, validationService, createTestService) {

        // formName - имя формы для валидации.
        $scope.create = function (formName) {
            if (!validationService.isValid(formName))
                return;

            // Вызываем метод сервиса работы с запросамы к серверу и передаем ему данные о юзере.
            // $scope в данном варианте содержит необходимое поле userName, которое принимает модель в параметре екшена.
            createTestService.saveUser($scope);
        };

        // Просто проверяем дата байдинг.
        $scope.test = "test";
       
    });


// Создаем фабрику для передачи запросов на сервер для сохранения юзера.
// Использует сервис httpService для общения с серверной стороной.
angular.module('mtApp').factory('createTestService', function (httpService) {
    return {
        // В фабрике описываем только 1 метод - сохранение пользователя.
        saveUser: function (user) {
            // Посылаем пост в екшен Create контроллера Test на cервер с данными о юзере.
            return httpService.post('Test/Create', user);
        }
    };
});