class Restaurant{
    constructor(budgetMoney){
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products){
        for (const product of products) {
            let splittedProducts = product.split(" ");
            let name = splittedProducts[0];
            let quantity = Number(splittedProducts[1]);
            let totalPrice = Number(splittedProducts[2]);
            let historyMessage = '';

            if (totalPrice <= this.budgetMoney) {
                this.budgetMoney -= totalPrice;
                historyMessage = `Successfully loaded ${quantity} ${name}`;

                if (Object.keys(this.stockProducts).includes(name)) {
                    this.stockProducts[name] += quantity;
                }else{
                    this.stockProducts[name] = quantity;
                }
            }else{
                historyMessage = `There was not enough money to load ${quantity} ${name}`;
            }

            this.history.push(historyMessage);
        }
        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price){
        if (!this.menu[meal]) {
            let neededProductsObjects = [];

            for (const product of neededProducts) {
                
                let splittedProduct = product.split(" ");

                let neededProduct = {
                    name: splittedProduct[0],
                    quantity: splittedProduct[1],
                }
                
                neededProductsObjects.push(neededProduct);
            }

            this.menu[meal] = {neededProductsObjects: neededProductsObjects, price: price};
            
            let numOfMeals = Object.keys(this.menu).length;
            
            if (numOfMeals == 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            }else{
                return `Great idea! Now with the ${meal} we have ${numOfMeals} meals in the menu, other ideas?`;
            }
        }else{
            return `The ${meal} is already in the our menu, try something different.`;
        }
    }

    showTheMenu(){
        let numOfMeals = Object.keys(this.menu).length;
            
        if (numOfMeals == 0) {
            return `Our menu is not ready yet, please come later...`;
        }else{
            let message = '';
            for (const meal in this.menu) {
                message += `${meal} - $ ${this.menu[meal].price}\n`;
            }
            return message;
        }
    }

    makeTheOrder(meal){
        if (!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`
        }
        
        for (const product of this.menu[meal].neededProductsObjects) {
            if (!this.stockProducts.hasOwnProperty(product.name)
                    || this.stockProducts[product.name]  < product ) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }

        this.budgetMoney += this.menu[meal].price;

        for (const product of this.menu[meal].neededProductsObjects) {
            this.stockProducts[product.name] -= product;
        }

        return `"Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}."`
        
    }
}