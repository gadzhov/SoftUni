function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}
let expect = require("chai").expect;

describe("lookup for char from string in position index", function () {
    it("with a non-string first parameter, should return undefined", function () {
        expect(lookupChar(20, 20)).to.be.equal(undefined);
    });
    it("with a non-number second parameter, should return undefined", function () {
        expect(lookupChar("text", "twenty")).to.be.equal(undefined);
    });
    it("with a a floating point number second parameter, should return undefined", function () {
        expect(lookupChar("text", 2.2)).to.be.equal(undefined);
    });
    it("with a index >= first parameter's length, should return incorrect index", function () {
        expect(lookupChar("text", 4)).to.be.equal("Incorrect index");
    });
    it("with a index < 0, should return incorrect index", function () {
        expect(lookupChar("text", -2)).to.be.equal("Incorrect index");
    });
    it("with correct parameters, should return correct value", function () {
        expect(lookupChar("text", 2)).to.be.equal("x");
    });
    it("with correct parameters, should return correct value", function () {
        expect(lookupChar("pesho", 3)).to.be.equal("h");
    });
});