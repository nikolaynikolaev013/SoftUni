class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.capacity == this.vehicles.length) {
            throw new Error("Not enough parking space.");
        }

        this.vehicles.push({ carModel, carNumber, payed: false });
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        let car = this.vehicles.find(x => x.carNumber == carNumber)
        if (!car) {
            throw new Error("The car, you're looking for, is not found.");
        } else if (car.payed == false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`)
        } else {
            let newArr = [];
            for (let i = 0; i < this.vehicles.length; i++) {
                if (this.vehicles[i] == car) {
                    continue;
                }
                newArr.push(this.vehicles[i]);
            }
            this.vehicles = newArr;
            return `${carNumber} left the parking lot.`;
        }
    }

    pay(carNumber) {
        let car = this.vehicles.find(x => x.carNumber == carNumber);

        if (!car) {
            throw new Error(`${carNumber} is not in the parking lot.`)
        } else if (car.payed == true) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`)
        }

        car.payed = true;
        //Todo: check if this works correctly!

        return `${carNumber}'s driver successfully payed for his stay.`
    }

    getStatistics(carNumber) {
        if (!carNumber) {
            let str = '';
            str += `The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.\n`;
            this.vehicles = this.vehicles.sort(function (a, b) {
                if (a.carModel.toLowerCase() < b.carModel.toLowerCase()) { return -1; }
                if (a.carModel.toLowerCase() > b.carModel.toLowerCase()) { return 1; }
                return 0;
            })
            for (let i = 0; i < this.vehicles.length; i++) {
                let currVehicle = this.vehicles[i];
                str += `${currVehicle.carModel} == ${currVehicle.carNumber} - ${currVehicle.payed ? "Has payed" : "Not payed"}\n`;
            }
            return str;
        } else {
            let currCar = this.vehicles.find(x => x.carNumber == carNumber);
            return `${currCar.carModel} == ${currCar.carNumber} - ${currCar.payed ? "Has payed" : "Not payed"}`;
            
        }

    }
}
