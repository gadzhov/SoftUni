function medenkaWars(input) {
    let white = [], dark = [];
    for (let attacks of input) {
        attacks = attacks.split(' ');
        if (attacks[1] === "white") {
            white.push(attacks[0]);
        } else {
            dark.push(attacks[0])
        }
    }
    let counter = 0;
    let damageW = 1;
    for (let i = 0; i < white.length; i++) {
        if (white[i] == white[i + 1]) {
            counter++;
            if (counter == 2) {
                white[i] *= 2.75;
            }
            damageW += white[i] * 60;
        } else {
            counter = 0;
        }
    }
    counter = 0;
    let damageD = 1;
    for (let i = 0; i < dark.length; i++) {
        if (dark[i] == dark[i + 1]) {
            counter++;
            if (counter == 5) {
                dark[i] *= 4.5;
            }
            damageD += dark[i] * 60;
        } else {
            counter = 0;
        }
    }
    console.log(damageW)
}
medenkaWars(['2 dark medenkas',
    '1 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas',
    '15 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas'
]);