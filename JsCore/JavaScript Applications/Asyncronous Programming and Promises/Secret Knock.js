function load() {
    const kinveyUser = "guest";
    const kinveyPassword = "guest";
    const base64auth = btoa(kinveyUser + ":" + kinveyPassword);
    const authHeaders = {"Authorization": "Basic " + base64auth};

    let url = "https://baas.kinvey.com/appdata/kid_BJXTsSi-e/knock";
    let query = "?query=";
    let message = "Knock Knock.";

getData();
    function getData() {
        let getRequest = {
            url: url + query + message,
            headers: authHeaders
        };
        $.ajax(getRequest)
            .then(printMessage)
            .catch(printError);

        function printMessage(msg) {
            console.log(msg.answer)
            if (msg.message) {
            console.log(msg.message);
            message = msg.message;
            getData()
            }
        }
        function printError(err) {
            console.log(err.statusText);
        }
    }
}