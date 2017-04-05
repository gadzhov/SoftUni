function startApp() {
    // Clear user data
    sessionStorage.clear();

    showHomeView();
    showHideMenuLinks();

    // Bind the navigation menu links
    $("#linkHome").click(showHomeView);
    $("#linkLogin").click(showLoginView);
    $("#linkRegister").click(showRegisterView);

    $("#linkListAds").click(showListAdvertisementsView);
    $("#linkCreateAd").click(createAdvertisementsView);     $("#linkLogout").click(logout);

    // Bind the form submit buttons
    $("#buttonLoginUser").click(login);
    $("#buttonRegisterUser").click(register);
    $("#buttonCreateAd").click(createAdvertisments);
    $("#buttonEditAd").click(editAdvertisments);

    // Bind the info / error boxes: hide on click
    $("#infoBox, #errorBox").click(function() {
        $(this).fadeOut();
    });

    // Kinvey properties
    const kinveyBaseUrl = "https://baas.kinvey.com/";
    const kinveyAppKey = "kid_ByjfuoK7e";
    const kinveyAppSecret =
        "aa521e9153ef4451818f2b4fc6d79c21";
    const kinveyAppAuthHeaders = {
        'Authorization': "Basic " +
        btoa(kinveyAppKey + ":" + kinveyAppSecret),
    };

    function showHideMenuLinks() {
        $("#menu a, span").hide();
        if (sessionStorage.getItem("authToken")) {
            $("#linkListAds").show();
            $("#linkCreateAd").show();
            $("#linkLogout").show();
            $("#loggedInUser").show();
        } else {
            $("#linkHome").show();
            $("#linkLogin").show();
            $("#linkRegister").show();
        }
    }

    function showView(viewName) {
        $('main > section').hide();
        $('#' + viewName).show();
    }

    function showInfo(message) {
        $('#infoBox').text(message);
        $('#infoBox').show();
        setTimeout(function() {
            $('#infoBox').fadeOut();
        }, 3000);
    }

    function showHomeView() {
        showView("viewHome")
    }

    function showRegisterView() {
        showView("viewRegister");
        $('#formRegister').trigger('reset');
    }

    function showLoginView() {
        showView("viewLogin");
        $('#formLogin').trigger('reset');
    }

    function getKinveyUserAuthHeaders() {
        return {
            "Authorization" : "Kinvey " + sessionStorage.getItem("authToken")
        }
    }

    function showListAdvertisementsView() {
        $('#ads table').empty();
        showView('viewAds');

        $.ajax({
            method: "GET",
            url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/items",
            headers: getKinveyUserAuthHeaders(),
            success: loadAdvertisements,
            error: handleAjaxError
        });
        function loadAdvertisements(items) {
            let table = $(`
                <table>
                <tr>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Publisher</th>
                    <th>Date Published</th>
                    <th>Price</th>
                    <th>Actions</th>
                </tr>
            </table>`);
            for (let item of items) {
                let tr = $('<tr>');
                displayTableRow(tr, item);
                tr.appendTo(table);
            }
            $("#ads").append(table);
        }
    }

    function displayTableRow(tr, item) {
        let links = [];
        if (item._acl.creator == sessionStorage.getItem("userId")) {
            let deleteLink = $("<a href='#'>[Delete]</a>").click(function () {
                deleteItemById(item._id)
            });
            let editLink = $("<a href='#'>[Edit]</a>").click(function () {
                loadItemForEdit(item._id)
            });
            links.push(deleteLink);
            links.push(" ");
            links.push(editLink);
        }
        tr.append(
            $("<td>").text(item.title),
            $("<td>").text(item.description),
            $("<td>").text(item._acl.creator), // TODO: to take the username
            $("<td>").text(item.date),
            $("<td>").text(item.price),
            $("<td>").append(links)
        )
    }

    function deleteItemById(itemId) {
        $.ajax({
            method: "DELETE",
            url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/items/" + itemId,
            headers: getKinveyUserAuthHeaders(),
            success: deleteItemSuccess,
            error: handleAjaxError
        });

        function deleteItemSuccess() {
            showListAdvertisementsView()
            showInfo("Item deleted.");
        }
    }

    function createAdvertisementsView() {
        showView("viewCreateAd");
        $('#formCreateAd').trigger('reset');
    }


    function login() {
        let userData = {
            username: $('#formLogin input[name=username]').val(),
            password: $('#formLogin input[name=passwd]').val()
        };
        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/login",
            data: userData,
            contextType: "application/json",
            headers: kinveyAppAuthHeaders,
            success: loginUserSuccess,
            error: handleAjaxError
        });

        function loginUserSuccess(userInfo) {
            saveAuthInSession(userInfo);
            showHideMenuLinks();
            showListAdvertisementsView();
            showInfo('Login successful.');
        }
    }
    
    function saveAuthInSession(userInfo) {
        sessionStorage.setItem('authToken', userInfo._kmd.authtoken);
        sessionStorage.setItem('userId', userInfo._id);
        sessionStorage.setItem('userName', userInfo.username);
        $('#loggedInUser').text("Welcome, " + userInfo.username + "!");
    }

    function register() {
        let userData = {
            username: $('#formRegister input[name=username]').val(),
            password: $('#formRegister input[name=passwd]').val()
        };
        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/",
            data: userData,
            contextType: "application/json",
            headers: kinveyAppAuthHeaders,
            success: registerUserSuccess,
            error: handleAjaxError
        });

        function registerUserSuccess(userInfo) {
            saveAuthInSession(userInfo);
            showHideMenuLinks();
            showListAdvertisementsView();
            showInfo('Registered successful.');
        }
    }

    function createAdvertisments() {
        let itemData = {
            title: $('#formCreateAd input[name=title]').val(),
            description: $('#formCreateAd textarea[name=description]').val(),
            date: $('#formCreateAd input[name=datePublished]').val(),
            price: $('#formCreateAd input[name=price]').val()
        };
        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/items",
            headers: getKinveyUserAuthHeaders(),
            data: itemData,
            success: createAdvertisementSuccess,
            error: handleAjaxError
        });

        function createAdvertisementSuccess() {
            showListAdvertisementsView();
            showInfo("Item created.");
        }
    }

    function loadItemForEdit(bookID) {
        $.ajax({
            method: "GET",
            url: kinveyBookUrl = kinveyBaseUrl + "appdata/" +
                kinveyAppKey + "/items/" + bookID,
            headers: getKinveyUserAuthHeaders(),
            success: loadItemsForEditSuccess,
            error: handleAjaxError
        });

        function loadItemsForEditSuccess(book) {
            $('#formEditAd input[name=id]').val(book._id);
            $('#formEditAd input[name=publisher]').val(book._acl.creator);
            $('#formEditAd input[name=title]')
                .val(book.title);
            $('#formEditAd textarea[name=description]')
                .val(book.description);
            $('#formEditAd input[name=datePublished]')
                .val(book.date);
            $('#formEditAd input[name=price]')
                .val(book.price);
            showView('viewEditAd');
        }
    }

    function editAdvertisments() {
        let itemData = {
            title: $('#formEditAd input[name=title]').val(),
            description: $('#formEditAd textarea[name=description]').val(),
            date: $('#formEditAd input[name=datePublished]').val(),
            price: $('#formEditAd input[name=price]').val()
        };
        $.ajax({
            method: "PUT",
            url: kinveyBaseUrl + "appdata/" + kinveyAppKey +
            "/items/" + $('#formEditBook input[name=id]').val(),
            headers: getKinveyUserAuthHeaders(),
            data: itemData,
            success: editBookSuccess,
            error: handleAjaxError
        });

        function editBookSuccess(response) {
            showListAdvertisementsView()
            showInfo('Item edited.');
        }
    }

    function logout() {
        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/_logout",
            "headers": {
                "content-type": "application/json",
                "authorization": "Kinvey " + sessionStorage.getItem("authToken"),
            },
            data: "",
            success: logoutSuccess,
            error: handleAjaxError
        });

        function logoutSuccess() {
            sessionStorage.clear();
            showHideMenuLinks();
            showHomeView();
            showInfo("Logout Successful")
        }
    }

    function handleAjaxError(response) {
        let errorMsg = JSON.stringify(response);
        if (response.readyState === 0)
            errorMsg = "Cannot connect due to network error.";
        if (response.responseJSON &&
            response.responseJSON.description)
            errorMsg = response.responseJSON.description;
        showError(errorMsg);
    }

    function showError(errorMsg) {
        $('#errorBox').text("Error: " + errorMsg);
        $('#errorBox').show();
    }
}