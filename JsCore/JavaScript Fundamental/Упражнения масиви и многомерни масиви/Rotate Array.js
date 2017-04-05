function rotateArray(input) {
    let rotation = Number(input.pop());
    let last = '';
    for (let i = 1; i <= rotation; i++) {
        last = input.pop();
        input.unshift(last);
    }
    console.log(input.join(' '));
}
rotateArray(['1', '2', '3', '4', '2']);