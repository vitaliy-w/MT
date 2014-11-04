(function () {
    var dependencies = ['ngSanitize', 'ngTagsInput', 'ngTable', 'ui.bootstrap'];
    angular.module('mtApp', dependencies);
})();

angular.extend(angular, {
    safeApply: function (scope, fn) {
        var phase = scope.$root.$$phase;
        if (phase == '$apply' || phase == '$digest') {
            if (fn && (typeof (fn) === 'function')) {
                fn();
            }
        } else {
            scope.$apply(fn);
        }
    }
});
