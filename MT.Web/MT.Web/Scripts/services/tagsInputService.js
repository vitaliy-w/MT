angular.module('mtApp').service('tagsInputService', ['tagsInputFactory', function ($q, httpService, tagsInputFactory) {
    this.load = function (query) {
        return tagsInputFactory.search(query);
    };
}]);

angular.module('ebamApp').factory('tagsInputFactory', function (httpService) {
    return {
        search: function (searchCriteria) {
            return httpService.post('Technology/Search', { query: searchCriteria });
        }
    };
});
