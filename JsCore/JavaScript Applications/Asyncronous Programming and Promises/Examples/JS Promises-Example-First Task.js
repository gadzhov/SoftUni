let p1 = new Promise(
    function (resolve, reject) {
        console.log("taks1 started.");
        setTimeout(function () {
            resolve("task1 result");
            console.log("task1 finished.")
        }, 1000);
    }
);
let p2 = new Promise(
    function (resolve, reject) {
        console.log("task2 started.");
        setTimeout(function () {
            resolve("task2 result");
            console.log("task2 finished")
        }, 1500);
    }
);
let p3 = new Promise(
    function (resolve, reject) {
        console.log("task3 started.");
        // reject('cannot eecute task3');
        setTimeout(function () {
            resolve("task3 result");
            console.log("task3 finished.")
        }, 500);
    }
);
console.log("All task started.");

Promise.all([p1, p2, p3])
    .then(function (result) {
        console.log("All tasks finished.");
        console.log("Result: " + result.join(", "));
        // nonExistingFunction();
    })
    .catch(function (error) {
        console.log("Some of the tasks failed.");
        console.log("Error: " + error)
    });