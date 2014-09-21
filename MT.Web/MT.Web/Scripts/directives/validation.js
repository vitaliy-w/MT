
// validation - form-level attribute
angular.module('mtApp').directive('validableForm', ['validationService', function (validationService) {
    return {
        restrict: 'A',
        require: '^form',
        link: function (scope, element, attrs, form) {
            // if the form inside template, it can be recreated by angular, so re-init validation
            if ($.validator && $.validator.unobtrusive && !element.data('unobtrusiveValidation'))
                $.validator.unobtrusive.parse(element);
            
            var validator = validationService.create(scope, element, form.$name);

            // intercept into jquery unobtrusive validation 
            var vlidator = element.validate();
            var origFunc = vlidator.settings.errorPlacement;
            var onError = function (error, inputElement) {
                var container = $(this).find("[data-valmsg-for='" + escapeAttributeValue(inputElement[0].name) + "']");
                if (container.length > 0)
                    origFunc(error, inputElement);
                else
                    error.data("unobtrusiveContainer", $('<div data-valmsg-replace="true">'));

                var key = error.attr('for');
                validator.addError(key, error.html());
            };
            var onSuccess = function(error) {
                var key = error.attr('for');
                validator.removeError(key);
            };
            var onErrors = function(event, validater) {
            };
            var escapeAttributeValue = function(value) {
                // As mentioned on http://api.jquery.com/category/selectors/
                return value.replace(/([!"#$%&'()*+,./:;<=>?@\[\\\]^`{|}~])/g, "\\$1");
            };

            vlidator.settings.errorPlacement = $.proxy(onError, element);
            vlidator.settings.success = $.proxy(onSuccess, form);
            //vlidator.settings.invalidHandler = $.proxy(onErrors, form);
        }
    };
}]);

// disable validation if hidden
angular.module('mtApp').directive('noValidateHidden', ['validationService', function (validationService) {
    return {
        restrict: 'A',
        require: '^form',
        link: function(scope, element, attrs, form) {
            scope.$watch(function() { return element.is(":hidden"); }, function(newValue) {
                if (newValue) {
                    validationService.removeError(form.$name, attrs.id);
                    element.attr('data-val', false);
                } else {
                    element.attr('data-val', true);
                }
            });
        }
    };
}]);
