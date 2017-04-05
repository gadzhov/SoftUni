function sum(input) {
    let  text = input[0];
    text = text.slice(15, text.length - 2);
    let result = text.split(' ')
    console.log(result);
}
sum(['console.log(add(1));'])