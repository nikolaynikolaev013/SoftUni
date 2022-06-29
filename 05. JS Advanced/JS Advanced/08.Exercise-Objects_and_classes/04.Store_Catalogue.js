function solve(input){
    let products = [];

    for (const row of input) {
        let data = row.split(' : ');

        products.push(new productFactory({productName: data[0], productPrice: Number(data[1])}));
    }

    let orderedProducts = products.sort(sortOn('productName'));

    let currLetter = orderedProducts[0].productName.charAt(0);
    console.log(`${currLetter}`);

    for (const product in orderedProducts) {

        let tempLetter = orderedProducts[product].productName.charAt(0);

        if (tempLetter != currLetter) {
            currLetter = tempLetter;
            console.log(`${currLetter}`);
        }

        console.log(`  ${orderedProducts[product].productName}: ${orderedProducts[product].productPrice}`);
    }    

    function productFactory(data){
        this.productName = data.productName;
        this.productPrice = data.productPrice;
    }

    function sortOn(property){
        return function(a, b){
            if(a[property] < b[property]){
                return -1;
            }else if(a[property] > b[property]){
                return 1;
            }else{
                return 0;   
            }
        }
    }
}

solve(['Banana : 2',
'Rubic\'s Cube : 5',
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10']

);