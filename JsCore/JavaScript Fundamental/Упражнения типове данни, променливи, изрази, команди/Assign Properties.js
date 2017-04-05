function assignProperties(input) {
    console.log("{");
    for (let i = 0; i < input.length; i += 2) {
        console.log(` ${input[i]}: '${input[i + 1]}' `);
        if (i < input.length - 2) {
            console.log(",")
        }
    }
    console.log("}")
}
//Не работи!!!
assignProperties(['name', 'Pesho', 'age', '23', 'gender', 'male']);