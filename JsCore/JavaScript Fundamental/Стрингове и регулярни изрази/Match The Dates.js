function dates(input) {
    let pattern = /([0-9]{1,2})-([A-Z][a-z]{2})-([0-9]{4})/g;
    let dates = [], match;
    for (let sentence of input) {
        while (match = pattern.exec(sentence)) {
            dates.push(`${match[0]} (Day: ${match[1]}, Month: ${match[2]}, Year: ${match[3]})`);
        }
    }
    console.log(dates.join("\n"));
}
dates(['1-Jun-2012 is before 14-Feb-2016']);