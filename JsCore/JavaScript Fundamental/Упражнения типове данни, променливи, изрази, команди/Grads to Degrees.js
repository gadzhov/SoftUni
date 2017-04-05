function gradsToDegrees([grads]) {
    [grads] = [grads].map(Number);
    let result = grads * 0.9;
    if (result > 0) {
        result = result % 360;
    }
    else {
        result = 360 + result;
    }
    console.log(result);
}
gradsToDegrees(['-50'])