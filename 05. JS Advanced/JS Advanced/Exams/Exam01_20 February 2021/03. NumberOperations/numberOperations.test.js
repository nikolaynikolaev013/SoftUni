const { assert } = require("chai");
const { expect } = require("chai");

const numberOperations = {
    powNumber: function (num) {
        return num * num;
    },

    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input < 100) {
            return 'The number is lower than 100!';
        } else {
            return 'The number is greater or equal to 100!';
        }
    },
    sumArrays: function (array1, array2) {

        const longerArr = array1.length > array2.length ? array1 : array2;
        const rounds = array1.length < array2.length ? array1.length : array2.length;

        const resultArr = [];

        for (let i = 0; i < rounds; i++) {
            resultArr.push(array1[i] + array2[i]);
        }

        resultArr.push(...longerArr.slice(rounds));

        return resultArr
    }
};


describe("Number operations tests", function() {
    describe("powNumber tests", function() {
        it("Should return a correct result", function() {
            let num1 = 2;
            let expected = num1 * num1;

            assert.equal(numberOperations.powNumber(num1), expected);
        });
     });

     describe("numberChecker tests", function() {
        it("Should throw when not a number", function() {
            expect(() => numberOperations.numberChecker('s')).to.throw();
        }); 
        it("Should return the number is lower than 100 when lower than 100", function() {
            assert.equal(numberOperations.numberChecker(99), 'The number is lower than 100!');
        });
        it("Should return the number is greater or equal to 100 when equal to 100", function() {
            assert.equal(numberOperations.numberChecker(100), 'The number is greater or equal to 100!');
        });
        it("Should return the number is greater or equal to 100 when greater to 100", function() {
            assert.equal(numberOperations.numberChecker(101), 'The number is greater or equal to 100!');
        });
     });

     describe("sumArrays tests", function() {
        it("Should return correct array", function() {
            let arr1 = [1, 2, 3];
            let arr2 = [3, 4, 5, 6];

            let expectedArr = [4, 6, 8, 6]
            let actualArr = numberOperations.sumArrays(arr1, arr2);
            expect(actualArr).to.eql(expectedArr)
        });
     });
});
