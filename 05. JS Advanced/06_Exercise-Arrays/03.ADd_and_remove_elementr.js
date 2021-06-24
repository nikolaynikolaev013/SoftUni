function manipulate(input){
    let counter = 1;
    let arr = [];

    input.forEach(comm => {
        if (comm === 'add') {
            arr.push(counter);
        }else if (comm === 'remove'){
            arr.pop();
        }
        counter++;
    });

    if (arr.length === 0) {
        console.log('Empty');
    }
    else{
        console.log(arr.join('\n'));
    }

}

manipulate(['remove', 
'remove', 
'remove']


);