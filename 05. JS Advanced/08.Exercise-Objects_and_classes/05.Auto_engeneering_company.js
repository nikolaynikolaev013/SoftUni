function solve(input){
    let brands = [];

    for (const row of input) {
        let splittedRow = row.split(' | ');
        let brand = splittedRow[0];
        let model = splittedRow[1];
        let quantity = Number(splittedRow[2]);

        if (!brands.find(x=>x.brandName === brand)) {
            let newBrand = {};

            newBrand.brandName = brand;

            newBrand.models = [];

            newBrand.models.push(new createModel({modelName: model, quantity: quantity}));
            brands.push(newBrand);
        }
        else if (!brands.find(x=>x.brandName === brand).models.find(x=>x.modelName === model)) {
            brands.find(x=>x.brandName === brand).models.push(new createModel({modelName: model, quantity: quantity}));
        }
        else{
            brands.find(x=>x.brandName === brand).models.find(x=>x.modelName === model).quantity += quantity;
        }
    }

    let str = '';

    for (const brand of brands) {
        let currBrand = brands.find(x=>x.brandName === brand.brandName)
        str += currBrand.brandName + '\n';
        for (const model of currBrand.models) {
            let currModel = currBrand.models.find(x=>x.modelName === model.modelName);
            str += `###${currModel.modelName} -> ${currModel.quantity}\n`;
        }
    }

    console.log(str);
    function createModel(input){
        this.modelName = input.modelName;
        this.quantity = input.quantity;
    }

}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);