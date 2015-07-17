(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("productResource", ["$resource",
                                     "appSettings",
                                     "currentUser",
                                     productResource]);

    //we could add http interceptor here for adding access token instead of inject http header
    //add token header here from window store
    function productResource($resource, appSettings, currentUser) {
        return $resource(appSettings.serverPath + "/api/products/:id", null, {
            'get': { headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token } },
            'save': { headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token } },
            'update': {
                method: 'PUT',
                headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
            } //add custom method called update that is PUT method
        });
    }
}());