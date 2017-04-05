function addRemoveElementsFromArray(input) {
    let n = 0;
    let result = [];
    for (let command of input ) {
        if (command == "add") {
            n += 1;
            result.push(n);
        }
        else if (command == "remove") {
            n += 1;
            result.pop();
        }
    }
    if (result.length) {
        console.log(result.join('\n'));
    }
    else {
        console.log('Empty');
    }
}
addRemoveElementsFromArray(['remove', 'remove', 'remove']);