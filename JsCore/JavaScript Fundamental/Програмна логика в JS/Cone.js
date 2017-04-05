function cone([r, h]) {
    [r, h] = [r, h].map(Number);
    let volume = (Math.PI * r * r * h) / 3;
    console.log("volume = " + Math.round(volume * 10000) / 10000);
    let s = Math.sqrt(r * r + h * h);
    let area = Math.PI * r * (r + s);
    console.log("area = " + Math.round(area * 10000) / 10000);
}
cone(['3', '5']);