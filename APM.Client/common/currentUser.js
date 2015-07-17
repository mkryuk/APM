(function () {
    "use strict";
    angular.module("common.services")
        .factory("currentUser", currentUser);

    function currentUser() {

        var profile = {
            isLoggedIn: false,
            username: "",
            token: ""
        };        

        function setProfile (username, token) {
            profile.username = username;
            profile.token = token;
            profile.isLoggedIn = true;
        }

        function getProfile () {
            return profile;
        }

        return {
            getProfile: getProfile,
            setProfile: setProfile
        };
    }
})();