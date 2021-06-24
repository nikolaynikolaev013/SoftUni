function findGDP(num1, num2){
    let smallerNum = Math.min(num1, num2);
    let biggestDivider = 1;

    for(let i = 1; i <= smallerNum; i++){
        if (num1 % i == 0 && num2 % i == 0){
            biggestDivider = i;
        }
    }

    console.log(biggestDivider);
}

findGDP(2154, 458);