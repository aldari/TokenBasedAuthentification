'use strict';
app.controller('historyController', ['$scope', '$http', 'historyService', function ($scope, $http, historyService) {
  $scope.filter = {};


  $scope.makerequest = function(filter){
    $http.post(
        'http://localhost:55452/'+'api/history',
        filter
    ).then(function (response) {
        $scope.history = response.data;
    });
  }

  $scope.makerequest($scope.filter) ;
}]);
