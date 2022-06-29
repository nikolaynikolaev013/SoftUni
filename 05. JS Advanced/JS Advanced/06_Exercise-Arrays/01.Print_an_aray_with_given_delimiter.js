function splitAndPrint(input){
    let delimiter = input[input.length - 1];
    input.pop();

    console.log(input.join(delimiter));
}

splitAndPrint([
'I',
'will', 
'not', 
'do', 
'it!', 
'_']
);