function rotate(input){
    let howManyTimes = Number(input.pop());

    for (let i = 0; i < howManyTimes / input.length; i++) {
        input.unshift(input.pop());
    }

    console.log(input.join(' '));
}

rotate(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']

);