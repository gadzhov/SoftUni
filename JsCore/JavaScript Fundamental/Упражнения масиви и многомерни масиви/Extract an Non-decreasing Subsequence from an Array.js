function extract(input) {
    let max = Number.NEGATIVE_INFINITY;
    function isBigger(value) {
        if (Number(value) >= max) {
            max = value;
            return value;
        }
    }
    console.log(input.filter(isBigger).join('\n'));
}
extract(['1','3','8','4','10','12','3','2','25']);