function printLetters(arr) {
    let text = arr[0];
    for (let i in text) {
        console.log(`str[${i}] -> ${text[i]}`);
    }
}
printLetters(['Hello, world!']);