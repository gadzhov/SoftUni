function triangleArea([a, b, c]) {
    [a, b, c] = [a, b, c].map(Number);
    let sp = (a + b + c) / 2;
    let area =
        Math.sqrt(sp * (sp - a) * (sp - b) * (sp - c));
    return area;
}
console.log(triangleArea(['2', '3.5', '4']));
// 3.4994419197923547
