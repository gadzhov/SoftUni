function biggestElementInMatrix(matrixRows) {
    let matrix = matrixRows
        .map(row => row
            .split(' ')
            .map(Number));
    let biggestNum = Number.NEGATIVE_INFINITY;
    matrix.forEach(
        r => r.forEach(
            c => biggestNum = Math.max(biggestNum, c)));
    console.log(biggestNum);
}
biggestElementInMatrix(['20 150 10', '9 33 145']);