function sumLastKNumbersSequence(input) {
    let n = Number(input[0]);
    let k = Number(input[1]);
    let seq = [1];
    let sum = 1;
    for (let  current = 1; current < n; current++) {
        let start = Math.max(0, current - k);
        let end = current - 1;
        for (let i = start; i < end; i++) {
            sum += seq[i];
        }
        seq.push(sum);
    }
    console.log(seq.join(' '));
}
sumLastKNumbersSequence(['9', '5']);