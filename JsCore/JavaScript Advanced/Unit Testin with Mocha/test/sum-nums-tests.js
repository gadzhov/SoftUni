let expect = require("chai").expect;
let sum = require("../sum-nums").sum;

describe("sum(arr) - sum array of numbers", function () {
    it("should return 3 for [1,2]", function () {
        let expectedSum = 3;
        let actualSum = sum([1,2]);
        expect(actualSum).to.be.equal(expectedSum);
    });
    it("should return 1 for [1]", function () {
        let expectedSum = 1;
        let actualSum = sum([1]);
        expect(actualSum).to.be.equal(expectedSum);
    });
    it("should return 3 for [1,2]", function () {
        let expectedSum = 3;
        let actualSum = sum([1,2]);
        expect(actualSum).to.be.equal(expectedSum);
    });
    it("should return 7 for [1.2,2.0,3.8]", function () {
        let expectedSum = 7;
        let actualSum = sum([1.2,2.0,3.8]);
        expect(actualSum).to.be.equal(expectedSum);
    });
    it("should return 0 for []", function () {
        let expectedSum = 0;
        let actualSum = sum([]);
        expect(actualSum).to.be.equal(expectedSum);
    });
    it("should return NaN for [vladi]", function () {
        let actualSum = sum(['vladi']);
        expect(actualSum).to.be.NaN;
    });
});