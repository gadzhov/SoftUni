function multiplication([n]) {
    [n] = [n].map(Number);
    console.log('<table border="1">');
    let result = '';
    for (let row = 0; row <= n; row++) {
        for (let col = 0; col <= n; col++) {
            if (row == 0) {
                if (row == 0 && col == 0) {
                    result += '<tr><th>x</th>';
                }
                else {
                    result += '<th>' + col + '</th>';
                    if (col == n) {
                        result += '</tr>' + "\n";
                    }
                }
            }
            else {
                if (col == 0 && row != 0) {
                    result += '<tr><th>' + row + '</th>'
                }
                else {
                    result += '<td>' + col * row + '</td>';
                    if (col == n) {
                        result += '<tr>' + "\n";
                    }
                }
            }
        }
    }
    result += '</table>';
    console.log(result);
}
multiplication(['5']);