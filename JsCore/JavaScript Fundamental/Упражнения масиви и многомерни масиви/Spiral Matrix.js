function spiralMatrix(matrixRows) {
    let matrix = [matrixRows[0]][matrixRows[1]];
    let row = 0;
    let col = 0;
    let direction = "right";
    let maxRotation = matrixRows[0] * matrixRows[1];
    console.log(maxRotation);
    for (let i = 1; i <= maxRotation; i++) {
        if (direction == "right" && (col > matrixRows[0] - 1 ||
            matrix[row][col] != 0)) {
            direction = "down";
            col--;
            row++;
        }
        if (direction == "down" && (row > matrixRows[0] - 1 ||
            matrix[row][col] != 0)) {
            direction = "left";
            row--;
            col--;
        }
        if (direction == "left" && (col < 0 || matrix[row][col]
            != 0)) {
            direction = "up";
            col++;
            row--;
        }
        if (direction == "up" && row < 0 || matrix[row][col] != 0) {
            direction = "right";
            row++;
            col++;
        }

        matrix[row][col] = i;
        if (direction == "right") {
            col++;
        }
        if (direction == "down") {
            row++;
        }
        if (direction == "left") {
            col--;
        }
        if (direction == "up") {
            row--;
        }
    }
    console.log(matrix.join('\n'));
}
spiralMatrix(['5', '5']);