function medenkaWars(inputLine) {
    let numberOfAttacks = 0;
    let leadersColor = '';

    let vitkorTotalDamage = 0;
    let naskorTotalDamage = 0;

    let vitkorAttacksCount = 0;
    let naskorAttacksCount = 0;

    let vitkorPreviousDamage = 0;
    let naskorPreviousDamage = 0;

    for (let i = 0; i < inputLine.length; i++) {
        let currentInputLine = inputLine[i].split(' ');
        numberOfAttacks = Number(currentInputLine[0]);
        leadersColor = currentInputLine[1];
        let damage = 60 * numberOfAttacks;

        if (leadersColor == "white") {
            if (vitkorPreviousDamage == damage) {
                vitkorAttacksCount++;
            } else {
                vitkorAttacksCount = 1;
            }

            if (vitkorAttacksCount == 2) {
                vitkorTotalDamage += damage * 2.75;
                vitkorPreviousDamage = damage * 2.75;
                vitkorAttacksCount = 0;
            } else {
                vitkorTotalDamage += damage;
                vitkorPreviousDamage = damage;
            }
        } else {
            if (naskorPreviousDamage == damage) {
                naskorAttacksCount++;
            } else {
                naskorAttacksCount = 1;
            }

            if (naskorAttacksCount == 5) {
                naskorTotalDamage += damage * 4.5;
                naskorPreviousDamage = damage * 4.5;
                naskorAttacksCount = 1;
            } else {
                naskorTotalDamage += damage;
                naskorPreviousDamage = damage;
            }
        }
    }
    if (vitkorTotalDamage > naskorTotalDamage) {
        console.log('Winner - Vitkor');
        console.log(`Damage - ${vitkorTotalDamage}`);
    } else {
        console.log('Winner - Naskor');
        console.log(`Damage - ${naskorTotalDamage}`);
    }
}
let str = ['2 dark medenkas',
'1 white medenkas',
'2 dark medenkas',
'2 dark medenkas',
'15 white medenkas',
'2 dark medenkas',
'2 dark medenkas'];
medenkaWars(str);
