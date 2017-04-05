function figure([n]) {
    [n] = [n].map(Number);
    let oddEvenRows = -1;
    let middle = Math.ceil(n / 2);
    if (n %  2 == 0) {
        oddEvenRows = n - 1;
    }
    else {
        oddEvenRows = n;
    }
    let result = '';
    for (let row = 1; row <= oddEvenRows; row++) {
        for (let col = 1; col <= 2 * n - 1; col++) {
            if (row == 1 || row == middle || row == oddEvenRows) {
                if (col == 1 || col == n || col == 2 * n - 1) {
                    result += '+';
                }
                else {
                    result += '-';
                }
            }
            else {
                if (col == 1 || col == n || col == 2 * n -1) {
                    result += '|';
                }
                else {
                    result += ' ';
                }
            }
        }
        result += "\n";
    }
    console.log(result);
}
figure(['2']);