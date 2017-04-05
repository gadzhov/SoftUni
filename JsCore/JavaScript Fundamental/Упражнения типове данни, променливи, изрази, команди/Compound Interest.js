function compoundInterest([p, i, n, t]) {
    [p, i, n, t] = [p, i, n, t].map(Number);
    let f = (1 + i / n);
    for (let i = 0; i < n * t; i++) {
        f *= f;
    }
    console.log(f * p);
}
compoundInterest(['1500', '4.3', '3', '6']);