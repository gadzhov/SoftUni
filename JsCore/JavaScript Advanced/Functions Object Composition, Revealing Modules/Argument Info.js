function result(argument) {
    let summary = {};
    for (let i = 0; i < argument.length; i ++) {
        let obj = argument[i];
        let type = typeof obj;
        console.log(`${type}: ${obj}`);
        if (!summary[type]) {
            summary[type] = 1;
        } else {
            summary[type]++;
        }
    }
    for (let s in summary) {
        console.log(`${s} = ${summary[s]}`)
    }
}
result(['cat', 42, function () { console.log('Hello world!'); }]);