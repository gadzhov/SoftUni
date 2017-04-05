function validate() {
    let userName = $("#username");
    let email = $("#email");
    let password = $("#password");
    let confirmPassword = $("#confirm-password");
    let company = $("#company");
    let companyInfo = $("#companyInfo");
    let companyNumber = $("#companyNumber");
    let submit = $("#submit");

    let usernameBool = false;
    let emailBool = false;
    let passwordBool = false;
    let confirmPasswordBool = false;
    let companyNumberBool = true;

    company.change(function () { // hide / show Company Info
        if (!this.checked) {
            companyInfo.css("display", "none");
        } else {
            companyInfo.css("display", "");
            companyNumberBool = false;
        }
    });

    function checkValidation(bool, id) {
        if (!bool) {
            id.css("border-color", "red")
        }
    }

    submit.on("click", function (ev) {
        ev.preventDefault();

        // username validation
        let regex = /[a-zA-Z0-9]+/gm;
        if (regex.test(userName.val()) && userName.val().length >= 3 && userName.val().length <= 20) {
            usernameBool = true;
        } else {
            usernameBool = false;
        }

        // email validation
        regex = /\w+@\w*\.*\w*/;
        if (regex.test(email.val())) {
            emailBool = true;
        } else {
            emailBool = false;
        }

        // password validation
        regex = /[a-zA-Z0-9_]+/;
        if (regex.test(password.val()) && password.val().length >= 5 && password.val().length <= 15 && password.val() == confirmPassword.val()) {
            passwordBool = true;
            confirmPasswordBool = true;
        } else {
            passwordBool = false;
            confirmPasswordBool = false;
        }

        // companyNumber validation
        regex = /\d+/;
        if (regex.test(companyNumber.val()) && companyNumber.val() >= 1000 && companyNumber.val() <= 9999) {
            companyNumberBool = true;
        }

        // valid div
        if (usernameBool && emailBool && passwordBool && confirmPasswordBool && companyNumberBool) {
            $("#valid").css("display", "");
        } else {
            $("#valid").css("display", "none");
        }

        checkValidation(usernameBool, userName);
        checkValidation(emailBool, email);
        checkValidation(passwordBool, password);
        checkValidation(confirmPasswordBool, confirmPassword);
        checkValidation(companyNumberBool, companyNumber);
    })
}
