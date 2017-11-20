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

    app.controller('rssController', ['$scope', 'dataFactory','$window',
       function ($scope, dataFactory, $window) {
           
           $scope.result = "";
           $scope.exceptionMessageText = ""; 
           

           function getInit() {
               dataFactory.getRssFeed('GetRssFeed')
               .then(function (response) {
                   $scope.status = 'ok';
                   $scope.result = response.data;
                  
                   }, function (error) {
                   $scope.exceptionMessageText = 'Unable to get rss feed: ' + error.message;
               });
           };

           $scope.redirectToItem = function (id) {
               var url = "http://" + $window.location.host + "/item.html?id="+ encodeURIComponent(id);
               $window.location.href = url;
           };


           getInit();
       }]);

    app.controller('rssItemController',['$scope', 'dataFactory','$window',
       function ($scope, dataFactory, $window) {
           
           $scope.item = "";
           $scope.exceptionMessageText = ""; 
           

           function getItem() {

               var url_string = $window.location.href;
               var url = new URL(url_string);
               var id = url.searchParams.get("id");
               var itemId = decodeURIComponent(id);
               
               var obj = {
                   'ItemId': itemId
               };
               dataFactory.getRssFeedById(obj, 'GetRssFeedById')
               .then(function (response) {
                   $scope.status = 'ok';
                   $scope.item = response.data;
                  
               }, function (error) {
                   $scope.exceptionMessageText = 'Unable to get rss feed item: ' + error.message;
               });
           };
           
           getItem();
       }]);



}());

