function calcFruitPrice(fruit, amount, pricePerKG){
    let grams = (amount /1000);
    let neededMoney = grams * pricePerKG;
    console.log(`I need $${neededMoney.toFixed(2)} to buy ${grams.toFixed(2)} kilograms ${fruit}.`);
}

calcFruitPrice('orange', 2500, 1.80);