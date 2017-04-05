function attachEvents() {
    const kinveyUserName = "guest";
    const kinveyPassword = "guest";
    const base64auth = btoa(kinveyUserName + ":" + kinveyPassword);
    const authHeaders = {"Authorization": "Basic " + base64auth};
    const url = "https://baas.kinvey.com/appdata/kid_Sy3iHeHfe/biggestCatches";
    let getRequest = {
        url: url,
        headers: authHeaders
    };

    let postRequest = {
        type: "POST",
        url: url,
        headers: authHeaders,
        contentType: "application/json"
    };

    $(".load").click(listAllCatches);
    $(".add").click(createNewCatch);

    function listAllCatches() {
        $.ajax(getRequest)
            .then(displayCatches)
            .catch(displayError);
    }

    function createNewCatch() {
        let dataJSON = JSON.stringify({
            "angler": $("#addForm .angler").val(),
            "weight": $("#addForm .weight").val(),
            "species": $("#addForm .species").val(),
            "location": $("#addForm .location").val(),
            "bait": $("#addForm .bait").val(),
            "captureTime": $("#addForm .captureTime").val()
        });
        $("#addForm .angler").val('');
        $("#addForm .weight").val('');
        $("#addForm .species").val('');
        $("#addForm .location").val('');
        $("#addForm .bait").val('');
        $("#addForm .captureTime").val('');
        postRequest.data = dataJSON;

        $.ajax(postRequest)
            .then(displayCatches) // Must fix it later!
            .catch(displayError); // --//---//--
    }
    let catchClone;
    catchClone = $('#catches .catch').clone(true, true);
    function displayCatches(catches) {
        for (let key in catches) {
            console.dir(catches[key]);
            let newCatch = catchClone;
            $("#catches").append(newCatch)
        }
    }
    function displayError(err) {
        console.log(err.statusText);
    }
}