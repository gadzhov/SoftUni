function leapYear(y) {
    let result = (y % 4 == 0 && y % 100 != 0) || y % 400 == 0;
    console.log(result ? "yes" : "no");
}

leapYear(1900);