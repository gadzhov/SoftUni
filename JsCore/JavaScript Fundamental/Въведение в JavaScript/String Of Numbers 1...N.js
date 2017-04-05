function stringOfNumbers(input) {
    let lengh = Number(input[0]);
    let output = "";
    for (let i = 1; i <= lengh; i++)
    {
        output += i;
    }
    return output;
}

stringOfNumbers(['11']);