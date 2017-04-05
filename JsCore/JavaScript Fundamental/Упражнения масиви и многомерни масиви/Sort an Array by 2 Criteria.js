function sortAnArrayByTwoCriteria(input) {
    console.log(input.sort().sort((a, b) => a.length - b.length).join('\n'));
}
sortAnArrayByTwoCriteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);