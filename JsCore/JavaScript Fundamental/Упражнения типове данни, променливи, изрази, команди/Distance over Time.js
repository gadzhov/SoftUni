function distanceOverTime([v1, v2, t]) {
    [v1, v2, t] = [v1, v2, t].map(Number);
    let s1 = v1 * t / 3600 * 1000;
    let s2 = v2 * t / 3600 * 1000;
    console.log(Math.abs(s1 - s2));
}
distanceOverTime(['11', '10', '120']);