function sumAndVat(input) {
    let sum = 0;
    for(let i = 0; i < input.length; i++)
    {
        sum += Number(input[i]);
    }
    let vat = sum * 0.20;
    console.log(`sum = ${sum}`);
    console.log(`VAT = ${vat}`);
    console.log(`total = ${sum * 1.20}`);
}

sumAndVat(['3.12', '5', '18', '19.24', '1953.2262', '0.001564', '1.1445']);