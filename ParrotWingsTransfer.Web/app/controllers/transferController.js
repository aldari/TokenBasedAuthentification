'use strict';
app.controller('transferController', ['$scope', '$http', function ($scope, $http) {
    $scope.getUser = function (val) {
        var serviceBase = 'http://localhost:55452';
        return $http.get(serviceBase + '/api/transfer/' + val).then(function (response) {
            return response.data.users.map(function (item) {
                return item;
            });
        });
    };

    $scope.formatUser = function (model) {
        return model ? model.name : '';
    }

    $scope.postTransfer = function (transfer) {
      console.log($scope.selectedUser);
      console.log(transfer);

        //if (!$scope.transferForm.$invalid && $scope.transferForm.$dirty) {
            var serviceBase = 'http://localhost:55452';
            $http({
                method: 'POST',
                url: serviceBase + '/api/transfer',
                data: { 'amount': transfer.amount, 'correspondent': $scope.selectedUser.id}
            }).success(function (result) {
                console.log('success');
            });
        //}
    }


        var serviceBase = 'http://localhost:55452';
        return $http.get(serviceBase + '/api/testusername/').then(function (response) {
            console.log(response.data);
        });
    
}]);
