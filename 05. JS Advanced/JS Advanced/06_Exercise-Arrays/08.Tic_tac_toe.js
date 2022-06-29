function play(input){
    let initialArray = [];
    
    initialArray = [
    [false, false, false],
    [false, false, false],
    [false, false, false],
    ];

    for (let i = 0; i < input.length; i++) {
        let currItem = input[i];
        let x = currItem[0];
        let y = currItem[1];

        if (initialArray[x,y] === true) {
            console.log("This place is already taken. Please choose another!");
            continue;
        }else{
            initialArray[x,y] = true;
            checkForWinningCombination()
        }
        
    }
    function checkForWinningCombination(arr){
        
    }
    function checkCombination(arr, x1, y1, x2, y2, x3, y3){
        if (arr[x1, y1] === true && arr[x2, y2] === true && arr[x3, y3] === true) {
            return true;
        }
        return false;
    }

    function printMatrix(initialArray){
            for (let row = 0; row < initialArray.length; row++) {
            let rowMsg = '';
            for (let col = 0; col < initialArray.length; col++) {
                rowMsg += initialArray[row, col];
            }
            console.log(rowMsg);
        }
    }
}

play(["0 1",
"0 0",
"0 2", 
"2 0",
"1 0",
"1 1",
"1 2",
"2 2",
"2 1",
"0 0"]
);