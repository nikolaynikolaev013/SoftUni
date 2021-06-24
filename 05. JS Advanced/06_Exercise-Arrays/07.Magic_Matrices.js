function checkIfMagical(input){
    let equal = true;

    for (let row = 0; row < input.length; row++) {
        let colSum = input[row].reduce((a,x) => a + x, 0);
        let rowSum = 0;
        for (let rowSum = 0; rowSum < input[row].length; rowSum++) {
            rowSum += Number(input[rowSum][row]);
        }

        if (colSum !== rowSum) {
            equal = false;
            break;
        }
    }
    
    console.log(equal);
}

checkIfMagical([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
   
   
   );