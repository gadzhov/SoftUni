function solve(input) {
    let point = Number(input[0]);
    for (let i = 1; i <= 5; i++) {
        switch (input[i]) {
            case 'chop': point /= 2; break;
            case 'dice': point = Math.sqrt(point); break;
            case 'spice': point += 1; break;
            case 'bake': point *= 3; break;
            case 'fillet': point -= point * 0.20; break;
            default: break;
        }
        console.log(point);
    }
}
solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);