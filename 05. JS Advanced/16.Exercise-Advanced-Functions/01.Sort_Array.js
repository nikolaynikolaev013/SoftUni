function solve(input, order){
    if (order === 'asc') {
        input.sort(function(a, b) {
            return a - b;
          })
    }else if (order === 'desc') {
        input.sort(function(a, b) {
            return b - a;
          })
    }

    return input;
};

console.log(solve([3, 1, 2, 10, 4, 8, 5, 7, 9, 20, 6], 'desc'));