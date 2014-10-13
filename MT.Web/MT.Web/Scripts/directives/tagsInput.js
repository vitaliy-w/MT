//tags input
angular.module('mtApp').directive('mtTagsInput', function () {
    var defaultTemplate = 'tags-input';
    var templatePathFormat = '/Views/Templates/{0}.html';

    return {
        restrict: 'A',
        templateUrl: function (node, attrs) {
            if (attrs && attrs['template'] && attrs['template'].length > 0) {
                return templatePathFormat.format(attrs['template']);
            }
            return templatePathFormat.format(defaultTemplate);
        },
        scope: {
            name: '@',
            modelValue: '=ngModel',
            items: '=',
            disabled: '=ngDisabled',
            ngChange: '&'
        },
        link: function (scope, element, attrs) {
            scope.onChange = function (value) {
                if (scope.modelValue !== value) {
                    scope.modelValue = value;
                    scope.ngChange();
                }
            };
        }
    };
});
