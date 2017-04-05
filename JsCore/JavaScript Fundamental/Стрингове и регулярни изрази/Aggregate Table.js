function aggregateTable(lines) {
    let list = [];
    let sum = 0;
    for (let line of lines) {
        let townData = line.split('|'),
            townName = townData[1].trim(),
            income = Number(townData[2].trim());
        list.push(townName);
        sum += income;
    }
    console.log(list.join(', ') + '\n' + sum);
}
aggregateTable(['| Sofia           | 300',
    '| Veliko Tarnovo  | 500',
    '| Yambol          | 275']
);