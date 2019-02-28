
var app = angular.module('Angularapp', ['ui.router','oc.lazyLoad']);
app.config(function ($stateProvider, $urlRouterProvider, $qProvider, $ocLazyLoadProvider) {

    $urlRouterProvider.otherwise('/Home');

    $stateProvider
        .state('Home', {
            url: '/Home',
            templateUrl: '/Views/Home.html'
        })
        .state('Department', {
            url: '/Department',
            templateUrl: '/App/Department/Department.html',
            controller: 'DeptController',
            resolve: {
                loadMyCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load(['/App/Department/DeptController.js','/App/Department/DeptService.js'], { cache: false });
                }]
            }
        })
        .state('Employee', {
            url: '/Employee',
            templateUrl: '/App/Employee/Employee.html',
            controller: 'EmployeeController',
            resolve: {
                loadMyCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load(['/App/Employee/EmployeeController.js', '/App/Employee/EmployeeService.js'], { cache: false });
                }]
            }
        })

    $qProvider.errorOnUnhandledRejections(false);
});




