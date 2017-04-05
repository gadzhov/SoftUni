function sortArray(inputArray, sortOrderCommand) {
    let sort = {
        asc: ((a, b) => a - b),
        desc: ((a, b) => b - a)
    };
    return inputArray.sort(sort[sortOrderCommand]);
}
sortArray([2,5,6,24,12,24,67], 'asc')