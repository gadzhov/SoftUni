function volume([x, y, z]) {
    [x, y, z] = [x, y, z].map(Number);
    function inVolume(x, y, z) {
        let x1 = 10, x2 = 50;
        let y1 = 20, y2 = 80;
        let z1 = 15, z2 = 50;

        if (x > x1 && x <= x2) {
            if (y >= y1 && y <= y2) {
                if (z >= z1 && z <= z2) {
                    return true;
                }
            }
        }
        return false;
    }
    if (inVolume(x, y, z)) {
        console.log('inside');
    } else {
        console.log('outside');
    }
}
volume(['13.1','50','31.5']);