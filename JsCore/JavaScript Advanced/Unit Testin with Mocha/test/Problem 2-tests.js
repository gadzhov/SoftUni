function createList() {
    let data = [];
    return {
        add: function (item) {
            data.push(item)
        },
        shiftLeft: function () {
            if (data.length > 1) {
                let first = data.shift();
                data.push(first);
            }
        },
        shiftRight: function () {
            if (data.length > 1) {
                let last = data.pop();
                data.unshift(last);
            }
        },
        swap: function (index1, index2) {
            if (!Number.isInteger(index1) || index1 < 0 || index1 >= data.length ||
                !Number.isInteger(index2) || index2 < 0 || index2 >= data.length ||
                index1 === index2) {
                return false;
            }
            let temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
            return true;
        },
        toString: function () {
            return data.join(", ");
        }
    };
}

let expect = require("chai").expect;

describe("createList", function () {
    let calc;
    beforeEach(function () {
        calc = createList();
    });
    it("should return  same value after {createList; add}", function () {
        calc.add(1);
        calc.add(2);
        let value = calc.toString();
        expect(value).to.be.equal("1, 2");
    });

    it("should return same value (floating points) after {createList; add}", function () {
        calc.add(1.5);
        calc.add(2.5);
        let value = calc.toString();
        expect(value).to.be.equal("1.5, 2.5");
    });
    it("should do nothing after createList.shiftLeft and data.length < 1", function () {
        calc.shiftLeft();
        let value = calc.toString();
        expect(value).to.be.equal("");
    });
    it("correct working shiftLeft}", function () {
        calc.add(5);
        calc.add(3);
        calc.add(7);
        calc.shiftLeft();
        let value = calc.toString();
        expect(value).to.be.equal("3, 7, 5");
    });
    it("should do nothing after createList.shiftRight and data.length < 1", function () {
        calc.shiftLeft();
        let value = calc.toString();
        expect(value).to.be.equal("");
    });
    it("correct working shiftRight}", function () {
        calc.add(5);
        calc.add(3);
        calc.add(7);
        calc.shiftRight();
        let value = calc.toString();
        expect(value).to.be.equal("7, 5, 3");
    });
    it("should do nothing after createList.swap if index 1 is not a Number", function () {
        calc.add(2);
        calc.add(5);
        calc.add(6);
        let value = calc.swap("text", 2);
        expect(value).to.be.equal(false);
    });
    it("should return false after createList.swap if index 2 is not a Number", function () {
        calc.add(2);
        calc.add(5);
        calc.add(6);
        let value = calc.swap(2, "text");
        expect(value).to.be.equal(false);
    });
    it("should return false after createList.swap if index 1 < 0", function () {
        calc.add(2);
        calc.add(5);
        calc.add(6);
        let value = calc.swap(- 1, 2);
        expect(value).to.be.equal(false);
    });
    it("should return false after createList.swap if index 2 < 0", function () {
        calc.add(2);
        calc.add(5);
        calc.add(6);
        let value = calc.swap(-1, -2);
        expect(value).to.be.equal(false);
    });
    it("should return false after createList.swap if index 1 >= data.length", function () {
        calc.add(2);
        calc.add(5);
        calc.add(6);
        let value = calc.swap(3, 2);
        expect(value).to.be.equal(false);
    });
    it("should return false after createList.swap if index 2 >= data.length", function () {
        calc.add(2);
        calc.add(5);
        calc.add(6);
        let value = calc.swap(2, 3);
        expect(value).to.be.equal(false);
    });
    it("should return false after createList.swap if index 1 === index 2", function () {
        calc.add(2);
        calc.add(5);
        calc.add(6);
        let value = calc.swap(1, 1);
        expect(value).to.be.equal(false);
    });
    it("should return true after createList.swap if indexes are in correct form", function () {
        calc.add(2);
        calc.add(5);
        calc.add(6);
        let value = calc.swap(0, 2);
        expect(value).to.be.equal(true);
    });
    it("correct working all operations", function () {
        calc.add(5);
        calc.add(3);
        calc.add(7);
        calc.shiftRight();
        calc.shiftLeft();
        calc.add("two");
        calc.add(["four"]);

        let value = calc.toString();
        expect(value).to.be.equal("5, 3, 7, two, four");
    });
});