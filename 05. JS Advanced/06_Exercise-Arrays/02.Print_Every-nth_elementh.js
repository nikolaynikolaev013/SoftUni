function printNthElement(input){
    let n = input.pop();

    for (let i = 0; i < input.length; i += Number(n)) {
        console.log(input[i]);
        
    }
}

printNthElement(['1', 
'2',
'3', 
'4', 
'5', 
'6']
);