function matchAllWords(input) {
    let text = input[0];
    console.log(text
        .split(/\W+/)
        .filter(w => w != '')
        .join('|'));
}
matchAllWords(['Some random words and letters and other things. In a sentence, also there are some signs like + or ? Sentences can also have semicolons; or dots. and !']);