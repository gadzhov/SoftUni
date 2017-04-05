function imperialUnits([foots]) {
    [foots] = [foots].map(Number);
    let inches = Math.floor(foots / 12);
    console.log(inches + "'-" + foots % 12 + '"');
}
imperialUnits(['11']);