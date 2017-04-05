function blog() {
    $("#posts-link").hide();
    $("#logout-link").hide();
    $("#register-link").click(registerView);
    $("#login-link").click(loginView);
    $("#logout-link").click(logoutView)

    const url = "https://baas.kinvey.com/";
    const appId = "kid_B19gxS7Ml";
    const appSecret = "0d09d6f74b78456ba0e0a9b96feb34a2";

    function checkSigned() {
        if (sessionStorage.getItem("authToken") == undefined) {
            $(".register-form").hide();
            $(".login-form").hide();
            $("#login-link").show();
            $("#register-link").show();

            $("#posts-link").hide();
            $("#logout-link").hide();

            $("#hello-user").text("");
        } else {
            $(".register-form").hide();
            $(".login-form").hide();
            $("#login-link").hide();
            $("#register-link").hide();

            $("#posts-link").show();
            $("#logout-link").show();

            $("#hello-user").text("Hello " + sessionStorage.getItem('userName'));
        }
    }

    function showRegisterView() {
        $(".register-form").css("display", '');
        $(".login-form").css("display", "none");
    }

    function showLoginView() {
        $(".register-form").css("display", 'none');
        $(".login-form").css("display", '');
    }

    function displayError(err) {
        $("#error-box").text(err.statusText);
        $("#error-box").show();
        setTimeout(function () {
            $("#error-box").hide();
        }, 3000);
    }

    $(document).on({
        ajaxStart: function () {
            $("#loading-box").show();
        },
        ajaxStop: function () {
            $("#loading-box").hide();
        }
    });

    function registerView() {
        showRegisterView();

        $(".submit-register").click(function (e) {
            let userName = $("#username-register").val();
            let password = $("#password-register").val();
            let data = JSON.stringify({
                username: userName,
                password: password
            });
            let settings = {
                "url": url + "user/" + appId,
                "method": "POST",
                "headers": {
                    "authorization": "Basic " + btoa(appId + ":" + appSecret),
                    "content-type": "application/json",
                },
                "processData": false,
                "data": data
            };
            $.ajax(settings)
                .then(registerSuccess)
                .catch(displayError);

            function registerSuccess() {
                $("#success-box").text("You registered success!");
                $("#success-box").show();
                setTimeout(function () {
                    $("#success-box").hide();
                }, 2000);
                checkSigned();

            }
        });
    }

    function loginView() {
        showLoginView();

        $(".submit-login").click(function (e) {
            let userName = $("#username-login").val();
            let password = $("#password-login").val();
            let data = JSON.stringify({
                username: userName,
                password: password
            });
            let settings = {
                "url": url + "user/" + appId + "/login",
                "method": "POST",
                "headers": {
                    "authorization": "Basic " + btoa(appId + ":" + appSecret),
                    "content-type": "application/json",
                },
                "processData": false,
                "data": data
            };
            $.ajax(settings)
                .then(loginSuccess)
                .catch(displayError);

            function loginSuccess(content) {
                sessionStorage.setItem('userName', content.username);
                sessionStorage.setItem('id', content._id);
                sessionStorage.setItem('authToken', content._kmd.authtoken);
                $("#success-box").text("You logged in as  " + content.username);
                $("#success-box").show();
                setTimeout(function () {
                    $("#success-box").hide();
                }, 2000);
                checkSigned();
            }
        });
    }

    function logoutView() {
        let settings = {
            "url": "https://baas.kinvey.com/user/" + appId + "/_logout",
            "method": "POST",
            "headers": {
                "content-type": "application/json",
                "authorization": "Kinvey " + sessionStorage.getItem("authToken"),
            },
            "data": ""
        };

        $.ajax(settings)
            .then(logOutSuccess)
            .catch(displayError);

        function logOutSuccess() {
            $("#success-box").text("You logout success!");
            $("#success-box").show();
            setTimeout(function () {
                $("#success-box").hide();
            }, 2000);
            sessionStorage.clear();
            checkSigned();
        }
    }
}