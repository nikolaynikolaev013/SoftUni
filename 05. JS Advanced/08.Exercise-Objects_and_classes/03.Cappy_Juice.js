function solve(input){
    let juices = {};
    let bottles = [];

    for (const juice of input) {
        let data = juice.split(' => ');
        
        if (juices[data[0]]) {
            juices[data[0]] += Number(data[1]);
        }
        else{
            juices[data[0]] = Number(data[1]);
        }

        let numOfBottles = 0;

        while (juices[data[0]] >= 1000) {
            juices[data[0]] -= 1000;
            numOfBottles++;
        }

        if (numOfBottles != 0) {
            if (bottles[data[0]]) {
                bottles[data[0]] += Number(numOfBottles);
            }
            else{
                bottles[data[0]] = numOfBottles;
            }
        }
    }


    for (const bottleKey in bottles) {
        console.log(`${bottleKey} => ${bottles[bottleKey]}`);
    }
}

solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']


);