let url = "https://baas.kinvey.com/appdata/kid_BJXTsSi-e/students";
let userPass64 = btoa("guest:guest");
let authoration = {"Authorization": "Basic " + userPass64};

let getRequest = {
    url: url,
    type: "GET",
    headers: authoration
};

$.ajax(getRequest)
    .then(displayStudents)
    .catch(displayError);

function displayStudents(students) {
    // console.dir(students);
    students.sort(function (a,b) {
        return a.ID - b.ID
    });
    for (let key in students) {
        let tr = $("<tr>");
        tr.append($("<td>").text(students[key].ID));
        tr.append($("<td>").text(students[key].FirstName));
        tr.append($("<td>").text(students[key].LastName));
        tr.append($("<td>").text(students[key].FacultyNumber));
        tr.append($("<td>").text(students[key].Grade));
        $("tbody").append(tr)
    }
}
function displayError(err) {
    alert(err)
}