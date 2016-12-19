var app = angular.module('AngularAuthApp', ['ngRoute', 'ngResource', 'LocalStorageModule', 'angular-loading-bar', 'ui.bootstrap', 'ngMessages','ui.bootstrap.showErrors']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/transfer", {
        controller: "transferController",
        templateUrl: "/app/views/transfer.html"
    });

    $routeProvider.when("/history", {
        controller: "historyController",
        templateUrl: "/app/views/history.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});
