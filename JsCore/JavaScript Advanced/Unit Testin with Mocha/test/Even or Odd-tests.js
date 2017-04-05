function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

let expect = require("chai").expect;
describe("string - odd / even length", function () {
    it("should return even for 20", function () {
        let expectedResult = 'even';
        let actualSum = isOddOrEven('20');
        expect(actualSum).to.be.equal(expectedResult);
    });
    it("should return odd for 3", function () {
        let expectedResult = 'odd';
        let actualSum = isOddOrEven('2');
        expect(actualSum).to.be.equal(expectedResult);
    });
    it("should return undefined for Number(20)", function () {
        let expectedResult = undefined;
        let actualSum = isOddOrEven([20]);
        expect(actualSum).to.be.equal(expectedResult);
    });
});