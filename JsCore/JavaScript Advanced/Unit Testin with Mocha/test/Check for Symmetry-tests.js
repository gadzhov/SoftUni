function isSymmetric(arr) {
    if (!Array.isArray(arr))
        return false; // Non-arrays are non-symmetric
    let reversed = arr.slice(0).reverse(); // Clone + reverse
    let equal =
        (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}

let expect = require("chai").expect;
describe("isSymmetric(arr) - Check for Symmetry an array", function () {
    it("should return true for [1,2,1]", function () {
        let expectedResult = true;
        let result = isSymmetric([1,2,1]);
        expect(result).to.be.equal(expectedResult);
    });
    it("should return false for [1,2,3,4]", function () {
        let expectedResult = false;
        let result = isSymmetric([1,2,3,4]);
        expect(result).to.be.equal(expectedResult);
    });
    it("should return true for []", function () {
        let expectedResult = true;
        let result = isSymmetric([]);
        expect(result).to.be.equal(expectedResult);
    });
    it("should return true for [1.1,2.2,1.1]", function () {
        let expectedResult = true;
        let result = isSymmetric([1.1,2.2,1.1]);
        expect(result).to.be.equal(expectedResult);
    });
    it("should return true for [-1,2,2,-1]", function () {
        let expectedResult = true;
        let result = isSymmetric([-1,2,2,-1]);
        expect(result).to.be.equal(expectedResult);
    });
    it("should return false for [-1,2,2,1]", function () {
        let expectedResult = false;
        let result = isSymmetric([-1,2,2,1]);
        expect(result).to.be.equal(expectedResult);
    });
    it("should return true for [5,'hello',{a:3},new Date(),{a:3},'hello',5]", function () {
        let expectedResult = true;
        let result = isSymmetric([5,'hello',{a:3},new Date(),{a:3},'hello',5]);
        expect(result).to.be.equal(expectedResult);
    });
    it("should return true for [1]", function () {
        let expectedResult = true;
        let result = isSymmetric([1]);
        expect(result).to.be.equal(expectedResult);
    });
    it("should return false for [1,2,3,4,5,6]", function () {
        let expectedResult = false;
        let result = isSymmetric([1,2,3,4,5,6]);
        expect(result).to.be.equal(expectedResult);
    });
    it("should return false for [1,2]", function () {
        let expectedResult = false;
        let result = isSymmetric([1,2]);
        expect(result).to.be.equal(expectedResult);
    });
    it("should return false for [5,'hello',{a:3},new Date(),{a:0},'hello',5]", function () {
        let expectedResult = false;
        let result = isSymmetric([5,'hello',{a:3},new Date(),{a:0},'hello',5]);
        expect(result).to.be.equal(expectedResult);
    });
    it("should return false for 1,2,3,2,1 (not an array)", function () {
        let expectedResult = false;
        let result = isSymmetric(1,2,3,2,1);
        expect(result).to.be.equal(expectedResult);
    });
});