function checkNumber(number){
    let numStr = String(number);
    
    let areEqual = true;
    let sum = 0;

    sum += Number(numStr[0]);

    for (let i = 1; i < numStr.length; i++){
        sum += Number(numStr[i]);
        if (!(numStr[i - 1] === numStr[i])){
            areEqual = false;
        }
    }

    console.log(Boolean(areEqual));
    console.log(sum);
}

checkNumber(2222223);