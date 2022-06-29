const { assert } = require("chai");

const cinema = {
    showMovies: function (movieArr) {

        if (movieArr.length == 0) {
            return 'There are currently no movies to show.';
        } else {
            let result = movieArr.join(', ');
            return result;
        }

    },
    ticketPrice: function (projectionType) {

        const schedule = {
            "Premiere": 12.00,
            "Normal": 7.50,
            "Discount": 5.50
        }
        if (schedule.hasOwnProperty(projectionType)) {
            let price = schedule[projectionType];
            return price;
        } else {
            throw new Error('Invalid projection type.')
        }

    },
    swapSeatsInHall: function (firstPlace, secondPlace) {
        if (!Number.isInteger(firstPlace) || firstPlace <= 0 || firstPlace > 20 ||
            !Number.isInteger(secondPlace) || secondPlace <= 0 || secondPlace > 20 ||
            firstPlace === secondPlace) {
            return "Unsuccessful change of seats in the hall.";
        } else {
            return "Successful change of seats in the hall.";
        }

    }
};


describe("Cinema", function () {
    describe("show movies", function () {
        it("no movies", function () {
            let movies = [];
            let expectedResult = 'There are currently no movies to show.';
            let actualResult = cinema.showMovies(movies);
            assert.equal(actualResult, expectedResult);
        });
        it("Should work", function () {
            let movies = ['movie1', 'movie2', 'movie3'];
            let expectedResult = 'movie1, movie2, movie3';
            let actualResult = cinema.showMovies(movies);
            assert.equal(actualResult, expectedResult);
        });
    });

    describe("ticket price", function () {
        it("Should work when premiere", function () {
            let type = 'Premiere';
            let expectedResult = 12.00;
            let actualResult = cinema.ticketPrice(type);

            assert.equal(actualResult, expectedResult);
        });
        it("Should work when normal", function () {
            let type = 'Normal';
            let expectedResult = 7.50;
            let actualResult = cinema.ticketPrice(type);

            assert.equal(actualResult, expectedResult);
        });
        it("Should work when discount", function () {
            let type = 'Discount';
            let expectedResult = 5.50;
            let actualResult = cinema.ticketPrice(type);

            assert.equal(actualResult, expectedResult);
        });
        it("Should throw when invalid projection type", function () {
            let type = 'nevaliden';
            assert.throws(() => cinema.ticketPrice(type), 'Invalid projection type.')
        });
    });

    describe("swap seats in hall", function () {
        it("invalid seat1", function () {
            let seat1 = 'chislo';
            let seat2 = 10;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });
        it("invalid seat2", function () {
            let seat1 = 12;
            let seat2 = 'chislo';
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });

        it("invalid seat1 - negative", function () {
            let seat1 = -1;
            let seat2 = 10;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });
        it("invalid seat2 - negative", function () {
            let seat1 = 14;
            let seat2 = -1;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });

        it("invalid seat1 - 0", function () {
            let seat1 = 0;
            let seat2 = 10;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });
        it("invalid seat2 - 0", function () {
            let seat1 = 14;
            let seat2 = 0;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });

        it("invalid seat1 - more than 20", function () {
            let seat1 = 21;
            let seat2 = 10;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });
        it("invalid seat2 - more than 20", function () {
            let seat1 = 4;
            let seat2 = 21;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });

        it("invalid - equal seat numbers", function () {
            let seat1 = 13;
            let seat2 = 13;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });

        it("invalid - seat1 - undefined", function () {
            let seat1 = undefined;
            let seat2 = 13;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });
        it("invalid - seat2 - undefined", function () {
            let seat1 = 13;
            let seat2 = undefined;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });
        it("invalid - both - undefined", function () {
            let seat1 = undefined;
            let seat2 = undefined;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });
        it("invalid - seat1 - empty", function () {
            let seat1 = '';
            let seat2 = undefined;
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });
        it("invalid - seat2 - empty", function () {
            let seat1 = undefined;
            let seat2 = '';
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });
        it("invalid - both - empty", function () {
            let seat1 = '';
            let seat2 = '';
            let expectedResult = 'Unsuccessful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(actualResult, expectedResult);
        });

        it("Should work correctly", function () {
            let seat1 = 3;
            let seat2 = 4;
            let expectedResult = 'Successful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(expectedResult, actualResult);
        });

        it("Should work correctly seat1", function () {
            let seat1 = 20;
            let seat2 = 7;
            let expectedResult = 'Successful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(expectedResult, actualResult);
        });
        it("Should work correctly seat2", function () {
            let seat1 = 9;
            let seat2 = 20;
            let expectedResult = 'Successful change of seats in the hall.';
            let actualResult = cinema.swapSeatsInHall(seat1, seat2);
            assert.equal(expectedResult, actualResult);
        });
    });
});
