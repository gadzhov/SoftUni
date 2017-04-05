function oddEven(input) {
    let num = Number(input[0]);
    if (num % 2 == 0) {
        console.log("even")
    }
    else if (num == Math.round(num)) {
        console.log("odd")
    }
    else {
        console.log("invalid")
    }
}

oddEven(['5']);
oddEven(['8']);
oddEven(['1.5']);