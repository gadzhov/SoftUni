function printEveryNthElement(input) {
    let delimiter = Number(input.pop());
    for (let i = 0; i <input.length; i += delimiter) {
        console.log(input[i]);
    }
}
printEveryNthElement(['2', '3', '1', '2']);