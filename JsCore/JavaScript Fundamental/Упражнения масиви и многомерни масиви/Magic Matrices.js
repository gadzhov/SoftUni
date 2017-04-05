function magicMatrices(matrixRows) {
    let matrix = matrixRows.map(
        row => row.split(' ').map(Number));
    let result = false;
    let sum = 0;
    let sumAll = 0;
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (row == 0) {
                sum += matrix[row][col];
            }
            sumAll += matrix[row][col];
        }
    }
    if (sumAll / matrix.length == sum){
        result = true;
    }
    console.log(result);
}
magicMatrices(['4 5 6',
    '6 5 4',
    '5 5 5']
);