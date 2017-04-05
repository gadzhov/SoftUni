function solution(array) {
    let startingYield = Number(array[0]);
    let yieldDrops = 10;
    let crewConsumes = 26;
    let days = 0;
    let totalAmount = 0;

    while (startingYield >= 100) {
        totalAmount += startingYield - crewConsumes;
        startingYield -= yieldDrops;
        days++;
    }
    if (totalAmount != 0) {
        totalAmount -= crewConsumes;
    }
    console.log(days);
    console.log(totalAmount);
}
solution(['111']);