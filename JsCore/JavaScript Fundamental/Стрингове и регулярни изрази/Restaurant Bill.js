function restaurantBill(text) {
    let result = text.filter((x, i) => i % 2 == 0);
    let price = text.filter((x, i) => i % 2 == 1)
        .map(Number)
        .reduce((a, b) => a + b);

    console.log(`You purchased ${result.join(', ')} for a total sum of ${price}`);
}
restaurantBill(['Beer Zagorka', '2.65', 'Tripe soup',
    '7.80','Lasagna', '5.69']);