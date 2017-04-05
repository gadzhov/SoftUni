function distanceIn3d([x1, y1, z1, x2, y2, z2]) {
    [x1, y1, z1, x2, y2, z2] = [x1, y1, z1, x2, y2, z2].map(Number);
    let d = Math.sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
    console.log(d);
}
distanceIn3d(['1', '1', '0', '5', '4', '0']);
