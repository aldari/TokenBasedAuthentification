app.factory('historyService', function ($resource) {
    return $resource('http://localhost:55452/api/history', null, {
    query: {
      method: 'GET',
      isArray: true,
      transformResponse: function(data) {
        return angular.fromJson(data).items;
      }
    }
  });
});
