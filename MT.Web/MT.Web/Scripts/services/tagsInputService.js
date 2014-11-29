angular.module('mtApp').service('tagsInputService', ['tagsInputFactory', function ($q, httpService, tagsInputFactory) {
    this.load = function (query) {
        return tagsInputFactory.search(query);
    };
}]);
