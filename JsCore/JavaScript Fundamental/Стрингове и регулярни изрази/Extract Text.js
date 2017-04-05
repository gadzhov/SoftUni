function extractText([text]) {
    let result = [];
    let startIndex = text.indexOf('(');
    while (startIndex > - 1) {
        let endIndex = text.indexOf(')', startIndex);
        if (endIndex == - 1)
            break;
        let snippets = text.substring(startIndex + 1, endIndex);
        result.push(snippets);
        startIndex = text.indexOf('(', endIndex);
    }
    console.log(result.join(', '));
}
extractText(['Rakiya (Bulgarian brandy) is self-made liquor ' +
'(alcoholic drink)']);