'use strict';
app.controller('historyController', ['$scope', '$http', 'historyService', function ($scope, $http, historyService) {

    //$scope.history = historyService.query();
    $scope.filter = {};

  $scope.makerequest = function(filter){
    console.log(filter);

    $http({
    url: 'http://localhost:55452/'+'api/history',
    method: "GET",
    params: { 'username': filter.username, 'amountmax': filter.amountmax, 'amountmin': filter.amountmin, 'datemin': filter.datemin, 'datemax': filter.datemax}
    });

  }
}]);
