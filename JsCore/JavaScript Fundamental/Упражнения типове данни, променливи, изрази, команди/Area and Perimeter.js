function areaAndPerimeter([a, b]) {
    [a, b] = [a, b].map(Number);
    let perimeter = (a + b) * 2;
    let area = a * b;
    console.log(area);
    console.log(perimeter);
}
areaAndPerimeter(['1', '3']);