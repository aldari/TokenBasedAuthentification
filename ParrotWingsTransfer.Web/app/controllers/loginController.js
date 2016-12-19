'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";


    $scope.login = function () {
      $scope.$broadcast('show-errors-check-validity');
      if ($scope.loginForm.$invalid) { return; }

      authService.login($scope.loginData).then(function (response) {
          $location.path('/transfer');
      },
      function (err) {
          $scope.message = err.error_description;
      });
    };

}]);
