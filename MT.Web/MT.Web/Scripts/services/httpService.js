angular.module('mtApp').factory('httpService', [
    '$http', '$q', '$interval', 'rootPath', '$window', function ($http, $q, $interval, rootPath, $window) {

        $window.downloadErrors = {};

        var doQuery = function(methodFunc) {
            var deferred = $q.defer();
            methodFunc().success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        };

        return {
            post: function(url, data) {
                return doQuery(function() { return $http.post(rootPath + url, data); });
            },
            
            get: function(url) {
                return doQuery(function() { return $http.get(rootPath + url); });
            },

            postAsForm: function (url, data) {
                var form = $('<form></form>');

                form.attr("method", "post");
                form.attr("action", url);

                $.each(data, function (key, value) {
                    var field = $('<input></input>');

                    field.attr("type", "hidden");
                    field.attr("name", key);
                    field.attr("value", value);

                    form.append(field);
                });

                $(document.body).append(form);
                form.submit();
            },
        };
    }
]);
