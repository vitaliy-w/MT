
angular.module('mtApp').factory('validationService', ['errorService', function (errorService) {
    var Validator = function (scope, form) {
        this.valid = true;
        this.keys = [];
        this.errors = [];
        var self = this;

        this.addError = function (key, error) {
            if (!error)
                return;
            var keyIndex = $.inArray(key, self.keys);
            var errorIndex = $.inArray(error, self.errors);
            if (keyIndex >= 0 && errorIndex >= 0)
                return;
            var replaceIndex = keyIndex >= 0 ? keyIndex : (errorIndex >= 0 ? errorIndex : -1);
            if (replaceIndex >= 0) {
                self.keys.splice(keyIndex, 1);
                self.errors.splice(keyIndex, 1);
            }
            self.keys.push(key);
            self.errors.push(error);
            self.valid = false;
        };
        this.removeError = function(key) {
            var index = $.inArray(key, self.keys);
            if (index >= 0) {
                self.keys.splice(index, 1);
                self.errors.splice(index, 1);
                self.valid = self.errors.length == 0;
                if (self.valid)
                    errorService.hideError(scope);
                angular.safeApply(scope);
            }
        };
        this.reset = function() {
            self.keys = [];
            self.errors = [];
            self.valid = true;
            errorService.hideError(scope);
        };
        this.validate = function () {
            var isValid = form.valid();
            if (isValid) {
                errorService.hideError(scope);
                return true;
            }
            errorService.showValidationError(scope, self.errors);
            return false;
        };
    };

    var validators = {};

    return {
        create: function (scope, form, name) {
            var validator = validators[name] = new Validator(scope, form);
            return validator;
        },
        removeError: function(formName, errorKey) {
            validators[formName].removeError(errorKey);
        },
        isValid: function(formName) {
            if (!validators.hasOwnProperty(formName))
                return true;

            //HACK: To remove validation-error for disabled elements, as they are not validated
            $('form[name="' + formName + '"] input[disabled=disabled]').removeClass('input-validation-error');

            return validators[formName].validate();
        },
        resetForm: function (formName) {
            var validator = validators[formName];
            if (validator) {
                validator.reset();
                $('form[name="' + formName + '"]').triggerHandler('reset.unobtrusiveValidation');
            }
        },
        resetAll: function(){
            angular.forEach(validators, function (validator, formName) {
                validator.reset();
                $('form[name="' + formName + '"]').triggerHandler('reset.unobtrusiveValidation');
            });
        }
    };
}]);