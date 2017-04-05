function lastMonth([day, month, year]) {
    [day, month, year] = [day, month, year].map(Number);
    let date = new Date(99,5,24);
    console.log(date);
}
lastMonth(['23','6','2002']);