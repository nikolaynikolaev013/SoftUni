const { assert } = require("chai");
const { expect } = require("chai");


const testNumbers = {
    sumNumbers: function (num1, num2) {
        let sum = 0;

        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        } else {
            sum = (num1 + num2).toFixed(2);
            return sum
        }
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input % 2 === 0) {
            return 'The number is even!';
        } else {
            return 'The number is odd!';
        }

    },
    averageSumArray: function (arr) {

        let arraySum = 0;

        for (let i = 0; i < arr.length; i++) {
            arraySum += arr[i]
        }

        return arraySum / arr.length
    }
};

describe("Test numbers tests", function() {
    describe("Sum numbers tests", function() {
        it("Should return undefined if number1 is not a number", function() {
            let expectedResult = undefined;
            let actualResult = testNumbers.sumNumbers('s', 1);

            assert.equal(expectedResult, actualResult);
        });

        it("Should return undefined if number2 is not a number", function() {
            let expectedResult = undefined;
            let actualResult = testNumbers.sumNumbers(1, '2');

            assert.equal(expectedResult, actualResult);
        });

        it("Should return correct answer", function() {
            let expectedResult = 5.55;
            let actualResult = testNumbers.sumNumbers(2.22, 3.3333);

            assert.equal(expectedResult, actualResult);
        });
     });

     describe("Number checker tests", function() {
        it("Should throw is input is not a number", function() {
            expect(() => testNumbers.numberChecker('s')).to.throw();
        });

        it("Should return the number is even with an even number", function() {
            let expectedResult = 'The number is even!';
            let actualResult = testNumbers.numberChecker(2);
            assert.equal(expectedResult, actualResult);
        });

        it("Should return the number is odd with an odd number", function() {
            let expectedResult = 'The number is odd!';
            let actualResult = testNumbers.numberChecker(3);
            assert.equal(expectedResult, actualResult);
        });
     });

     describe("Average sum array tests", function() {
        it("Should return a correct answer", function() {
            let arr = [1, 2, 3];

            let expectedResult = 2
            let actualResult = testNumbers.averageSumArray(arr);
            assert.equal(expectedResult, actualResult);
        });
     });
});
