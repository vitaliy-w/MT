angular.module('mtApp').directive('mtErrorContainer', ['broadcastIds', function (broadcastIds) {

    var inputErrorProperties = null;

    return {
        restrict: 'A',
        controller: ['$scope', function ($scope) {
            $scope.error = {
                show: false
            };

            function validationHighlight(obj) {

                // Highlights validation-fail DOM elements.
                if (obj && obj.errorProperties) {
                    inputErrorProperties = [];
                    $.each(obj.errorProperties, function (index, value) {
                        inputErrorProperties.push($('input[name="' + value + '"]'));
                        $('input[name="' + value + '"]').addClass('input-validation-error').closest('.fieldset').addClass('invalid-fieldset');
                    });
                }
            }

            function setupErrorOrValidation(event, obj) {
                event.stopPropagation();

                var err = $scope.error;

                if (inputErrorProperties) {
                    $.each(inputErrorProperties, function (idx, item) {
                        item.removeClass('input-validation-error').closest('.fieldset').removeClass('invalid-fieldset');
                    });
                    inputErrorProperties = null;
                }

                if (!obj) {
                    err.show = false;
                    err.isError = false;
                    return;
                }

                err.show = true;
                if (angular.isString(obj))
                    err.title = obj;
                else if (angular.isArray(obj))
                    err.messages = obj;
                else {
                    var title = obj.title;
                    var messages = obj.messages;

                    if (!title && !messages)
                        return;

                    err.isError = obj.isError ? true : false;

                    if (title)
                        err.title = title;
                    if (messages)
                        err.messages = messages;
                    if (obj['iconUrl'])
                        err.iconUrl = obj.iconUrl;
                }


                err.show = true;
                angular.safeApply($scope);
            }
            
            $scope.$on(broadcastIds.error, function (event, obj) {
                setupErrorOrValidation(event, obj);
                validationHighlight(obj);
            });

            $scope.$on(broadcastIds.validation, function (event, obj) {
                setupErrorOrValidation(event, obj);
                validationHighlight(obj);
            });
        }]
    };
}]);

angular.module('mtApp').directive('mtErrorMessage', function () {
    return {
        restrict: 'A',
        templateUrl: '/Views/Templates/error-message.html',
        require: '^mtErrorContainer'
    };
});
