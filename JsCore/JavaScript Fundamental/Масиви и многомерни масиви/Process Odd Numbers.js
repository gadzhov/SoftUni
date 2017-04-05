function oddNumbers(arr) {
    let result = arr
        .filter((num, i) => i % 2 == 1)
        .map(x => 2*x)
        .reverse();
    return console.log(result.join(' '));
}
oddNumbers(['10', '15', '20', '25']);