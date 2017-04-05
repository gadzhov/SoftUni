function rgbToHexColor(red, green, blue) {
    if (!Number.isInteger(red) || (red < 0) || (red > 255))
        return undefined; // Red value is invalid
    if (!Number.isInteger(green) || (green < 0) || (green > 255))
        return undefined; // Green value is invalid
    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255))
        return undefined; // Blue value is invalid
    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}

let expect = require("chai").expect;

describe("Nominal cases (valid input)", function () {
    it("HEX color should be #FF9EAA for (255,158,170)", function () {
        let hex = rgbToHexColor(255,158,170);
        expect(hex).to.be.equal('#FF9EAA');
    });
    it("HEX color should be #0C0D0E for (12,13,14)", function () {
        let hex = rgbToHexColor(12,13,14);
        expect(hex).to.be.equal('#0C0D0E');
    });
    it("HEX color should be #000000 for (0,0,0,)", function () {
        let hex = rgbToHexColor(0,0,0);
        expect(hex).to.be.equal('#000000');
    });
    it("HEX color should be #FFFFFF for (255,255,255)", function () {
        let hex = rgbToHexColor(255,255,255);
        expect(hex).to.be.equal('#FFFFFF');
    });
    describe("Special cases (invalid inout)", function () {
        it("HEX color should be undefined for (-1,0,0)", function () {
            let hex = rgbToHexColor(-1,0,0);
            expect(hex).to.be.equal(undefined)
        });
        it("HEX color should be undefined for (\"5\",[3],{8:9})", function () {
            let hex = rgbToHexColor("5", [3], {8:9});
            expect(hex).to.be.equal(undefined)
        });
        it("HEX color should be undefined for (3.14,0,0)", function () {
            let hex = rgbToHexColor(3.14,0,0);
            expect(hex).to.be.equal(undefined)
        });
        it("HEX color should be undefined for (256,0,0)", function () {
            let hex = rgbToHexColor(256,0,0);
            expect(hex).to.be.equal(undefined)
        });
        it("HEX color should be undefined for ()", function () {
            let hex = rgbToHexColor();
            expect(hex).to.be.equal(undefined)
        });
    });
});