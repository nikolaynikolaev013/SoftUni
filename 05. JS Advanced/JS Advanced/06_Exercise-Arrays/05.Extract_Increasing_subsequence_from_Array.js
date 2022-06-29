function extract(input){
    let biggestOne = Number.MIN_SAFE_INTEGER;

    let newArr = input.filter(x=>{
        if (x >= biggestOne) {
            biggestOne = x;
            return true;
        }
        return false;
    });

    console.log(newArr.join('\n'));
}

extract([20, 
3, 
2, 
15,
6, 
1]

    );