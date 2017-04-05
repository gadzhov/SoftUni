function rounding([n, p]) {
    [n, p] = [n, p].map(Number);
    let percision = 1;
    for (let i = 1; i <= p; i++) {
        percision *= 10;
    }
    console.log(Math.round(n * percision) / percision);
}
rounding(['10.5', '3']);