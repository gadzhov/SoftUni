function binaryToDecimal([binary]) {
    [binary] = [binary].map(Number)
    let decimal = parseInt(binary, 2);
    console.log(decimal);
}
binaryToDecimal(['00001001'])