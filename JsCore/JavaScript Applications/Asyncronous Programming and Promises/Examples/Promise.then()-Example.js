console.log('Before promise');

new Promise(function (resolve, reject) {
    setTimeout(function () {
        resolve('done');
    }, 500);
})
.then(function (result) {
    console.log('Then returned: ' + result);
});
console.log('After promise');