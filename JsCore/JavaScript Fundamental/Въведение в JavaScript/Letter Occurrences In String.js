function letterOccurrences([str, letter]) {
    let result = 0;
    for(let i = 0; i < str.length; i++)
    {
        if (str[i] == letter)
        {
            result++;
        }
    }
    console.log(result);
}

letterOccurrences(['hello', 'l']);