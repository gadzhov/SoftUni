function colorfulNumbers([n]) {
    [n] = [n].map(Number);
    console.log("<ul>");
    for (let i = 1; i <= n; i++) {
        let color = i % 2 == 0 ? "blue" : "green";
        console.log(`\t<li><span style="color: ${color}">${i}</span></li>`)
    }
    console.log("</ul>");

}
colorfulNumbers(['10']);