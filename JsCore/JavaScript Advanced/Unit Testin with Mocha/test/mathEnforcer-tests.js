let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};
let expect = require("chai").expect;

describe('mathEnforcer', function () {
    describe('addFive', function () {
        it('with a non-number parameter, should return undefined', function () {
            expect(mathEnforcer.addFive("string")).to.be.equal(undefined);
        });
        it('with a number parameter, should return correct result', function () {
            expect(mathEnforcer.addFive(5)).to.be.equal(10);
        });
    });
    describe('substractTen', function () {
        it('with a non-number parameter, should return undefined', function () {
            expect(mathEnforcer.subtractTen("string")).to.be.equal(undefined);
        });
        it('with a number parameter, should return correct result', function () {
            expect(mathEnforcer.subtractTen(15)).to.be.equal(5);
        });
    });
    describe('sum', function () {
        it('with a non-number first parameter, should return undefined', function () {
            expect(mathEnforcer.sum("string", 2)).to.be.equal(undefined);
        });
        it('with a non-number second parameter, should return undefined', function () {
            expect(mathEnforcer.sum(2, "string")).to.be.equal(undefined);
        });
        it('with two numbers, should return their sum', function () {
            expect(mathEnforcer.sum(2, 4)).to.be.equal(6);
        });
        it('with two float point numbers, should return their sum', function () {
            expect(mathEnforcer.sum(2.2, 4.4)).to.be.equal(2.2 + 4.4);
        });
        it('with two negative numbers, should return their sum', function () {
            expect(mathEnforcer.sum(-10, -5)).to.be.equal(-15);
        });
    });
});