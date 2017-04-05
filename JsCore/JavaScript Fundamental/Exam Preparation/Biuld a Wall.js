function build(array) {
    let starting = array.map(x => Number(x));
    let concrete = 0;
    let daily = [];

    while(starting.length > 0) {
        for (let position = 0; position < starting.length; position++) {
            if (starting[position] < 30) {
                starting[position]++;
            } else {
                starting.splice(position, 1);
                position--;
            }
        }
        concrete += starting.length * 195;
        if (starting.length) {
            daily.push(starting.length * 195);
        }
    }
    console.log(daily.join(', '));
    console.log(concrete * 1900 + " pesos");
}
build([17, 22, 17, 19, 17]);