function roadRadar([speed, area]) {
    [speed].map(Number);
    function speedTest(speed, area) {
        if (area == 'motorway' && speed > 130) {
            if (speed <= 150) {
                console.log('speeding');
            }
            else if (speed <= 170) {
                console.log('excessive');
            }
            else {
                console.log('reckless driving')
            }
        }
        if (area == 'interstate' && speed > 90) {
            if (speed <= 110) {
                console.log('speeding');
            }
            else if (speed <= 130) {
                console.log('excessive');
            }
            else {
                console.log('reckless driving')
            }
        }
        if (area == 'city' && speed > 50) {
            if (speed <= 70) {
                console.log('speeding');
            }
            else if (speed <= 90) {
                console.log('excessive');
            }
            else {
                console.log('reckless driving')
            }
        }
        if (area == 'residential' && speed > 20) {
            if (speed <= 40) {
                console.log('speeding');
            }
            else if (speed <= 60) {
                console.log('excessive');
            }
            else {
                console.log('reckless driving')
            }
        }
    }
    speedTest(speed, area);
}
roadRadar(['40', 'city']);
roadRadar(['21', 'residential']);
roadRadar(['120', 'interstate']);
roadRadar(['200', 'motorway']);