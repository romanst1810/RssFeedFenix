(function () {
    var app = angular.module('rss-app', []);

    app.factory('dataFactory', ['$http', function ($http) {

        var urlBase = '/api/Rss';
        var dataFactory = {};

        dataFactory.getRssFeed = function (obj, methodName) {
            return $http.post(urlBase + '/' + methodName, obj);
        };

        return dataFactory;
    }]);
    app.filter('unsafe', function ($sce) { return $sce.trustAsHtml; });
    app.controller('rssController', ['$scope', 'dataFactory',
       function ($scope, dataFactory) {
           
           $scope.result = "";
           $scope.status = "";
           $scope.myStyle = {};
           $scope.exceptionMessageText = ""; 
           

           function getInit() {
               var operationId = "LoadFromUrl";
               
               var obj = {
                   'OperationId': operationId
               };
               dataFactory.getRssFeed(obj, 'GetRssFeed')
               .then(function (response) {
                   $scope.status = 'ok';
                   $scope.result = response.data;
                   //angular.forEach($scope.result, function (value, key) {
                   //    value._description = $sce.trustAsHtml(value._description);
                   //});
                   }, function (error) {
                   $scope.exceptionMessageText = 'Unable to get rss feed: ' + error.message;
               });
           };



           getInit();
       }]);
}());