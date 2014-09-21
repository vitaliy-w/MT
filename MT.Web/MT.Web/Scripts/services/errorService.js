angular.module('mtApp').factory('errorService', ['errorModel', 'broadcastIds', function (errorModel, broadcastIds) {
    var validationTitle = errorModel.validationTitle;

    var numberMapping = ["Zero", "One", "Two", "Three", "Four", "Five",
                    "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
                    "Twelve", "Thirteen", "Fourteen", "Fifteen",
                    "Sixteen", "Seventeen", "Eighteen", "Nineteen",
                    "Twenty", "Twenty One", "Twenty Two", "Twenty Three",
                    "Twenty Four", "Twenty Five", "Twenty Six", "Twenty Seven",
                    "Twenty Eight", "Twenty Nine", "Thirty", "Thirty One",
                    "Thirty Two", "Thirty Three",
                    "Thirty Four", "Thirty Five", "Thirty Six", "Thirty Seven",
                    "Thirty Eight", "Thirty Nine", "Fourty", "Fourty One",
                    "Fourty Two", "Fourty Three",
                    "Fourty Four", "Fourty Five", "Fourty Six", "Fourty Seven",
                    "Fourty Eight", "Fourty Nine", "Fifty"];

    function wrapMessagesWithSpan(messages) {
        var messageArray = [];
        angular.forEach(messages, function (value) {
            messageArray.push(value.toLocaleLowerCase().indexOf('<span') < 0 ? ('<span>' + value + '</span>') : value);
        });
        return messageArray;
    }

    return {
        showError: function (scope, obj) {
            if (obj && obj.messages) {
                obj.messages = wrapMessagesWithSpan(obj.messages);
                if (typeof (obj.isError) == "undefined") {
                    obj.isError = true;
                }
            }
            scope.$emit(broadcastIds.error, obj);
        },
        showValidationError: function (scope, messages) {
            if (!messages || !angular.isArray(messages) || messages.length == 0)
                return;

            var amount = '' + (messages.length < numberMapping.length ? numberMapping[messages.length] : messages.length);

            var err = {
                title: amount + ' ' + validationTitle,
                messages: wrapMessagesWithSpan(messages),
                show: true,
                isError: false
            };
            scope.$emit(broadcastIds.validation, err);
        },
        hideError: function (scope) {
            scope.$emit(broadcastIds.error, null);
        }
    };
}]);
