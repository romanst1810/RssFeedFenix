(function () {
    var app = angular.module('rss-app', []);

    app.factory('dataFactory', ['$http', function ($http) {

        var urlBase = '/api/Rss';
        var dataFactory = {};

        //dataFactory.getRssFeed = function (obj, methodName) {
        //    return $http.post(urlBase + '/' + methodName, obj);
        //};
        dataFactory.getRssFeed = function (methodName) {
            return $http.get(urlBase + '/' + methodName);
        };

        dataFactory.getRssFeedById = function (obj, methodName) {
            return $http.post(urlBase + '/' + methodName, obj);
        };
        return dataFactory;
    }]);

    app.filter('unsafe', function ($sce) { return $sce.trustAsHtml; });

    app.controller('rssController', ['$scope', 'dataFactory',
       function ($scope, dataFactory) {
           
           $scope.result = "";
           $scope.exceptionMessageText = ""; 
           

           function getInit() {
               //var operationId = "LoadFromUrl";
               
               //var obj = {
               //    'OperationId': operationId
               //};
               //dataFactory.getRssFeed(obj, 'GetRssFeed')
               dataFactory.getRssFeed('GetRssFeed')
               .then(function (response) {
                   $scope.status = 'ok';
                   $scope.result = response.data;
                  
                   }, function (error) {
                   $scope.exceptionMessageText = 'Unable to get rss feed: ' + error.message;
               });
           };



           getInit();
       }]);
}());