function solve(input) {
        let quiz = '<?xml version="1.0" encoding="UTF-8"?>' + "\n";
        quiz += '<quiz>';
        for (let i = 0; i < input.length; i += 2) {
            let question = input[i];
            let answer = input[i + 1];
            quiz += '\n\t<qustion>' + "\n" + "\t\t" + question + "\n" + '\t</qustion>';
            quiz += "\n" + '\t<answer>' + "\n\t\t" + answer + "\n" + '\t</answer>';
        }
        quiz += "\n" + '</quiz>';
        console.log(quiz);
}
solve(["Dry ice is a frozen form of which gas?",
    "Carbon Dioxide",
    "What is the brightest star in the night sky?",
    "Sirius"]
);