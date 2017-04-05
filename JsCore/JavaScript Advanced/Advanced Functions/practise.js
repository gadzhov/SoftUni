function aggregate(arr) {
    console.log("Sum is: " +
    reducer(arr, (a, b) => Number(a) - Number(b)));

    function reducer(arr, func) {
        let result = arr[0];
        for (let nextElement of arr.slice(1)) {
            result = func(result, nextElement);
        }
        return result;
    }
}
aggregate([2,3,10,5]);