function countWords(textLine) {
    let words = textLine
        .join('/\n')
        .split(/[^A-Za-z0-9]+/)
        .filter(w => w != '');
    let wordsCount = {};
    for (let w of words) {
        wordsCount[w] ? wordsCount[w]++ : wordsCount[w] = 1;
    }
    console.log(JSON.stringify(wordsCount));
}
countWords(['JS and Node.js', 'JS again and again', 'Oh, JS?']);