function chessBoard([n]) {
    let color = "black";
    console.log('<div class="chessboard">');
    for (let row = 1; row <= n; row++) {
        console.log("  <div>");
        for (let col = 1; col <= n; col++) {
            console.log(`    <span class="${color}"></span>`);
            if (color == "black") {
                color = "white";
            }
            else {
                color = "black";
            }
        }
        if (n % 2 == 0) {
            if (color = "white") {
                color = "black";
            }
            else {
                color = "white";
            }
        }
        console.log("  </div>");
    }
    console.log('</div>');
}
chessBoard(['3']);