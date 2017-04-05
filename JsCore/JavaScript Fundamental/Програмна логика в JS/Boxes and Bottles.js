function boxesAndBottles([number, capacity]) {
    let result = Math.ceil(number / capacity);
    console.log(result);
}

boxesAndBottles(['20', '5']);
boxesAndBottles(['15', '7']);
boxesAndBottles(['5', '10']);