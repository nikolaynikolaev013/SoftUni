function solve(...input){
    class Person{
        constructor(personName, age, weight, height){
            this.name = personName;
            this.personalInfo = {};
            this.personalInfo.age = age;
            this.personalInfo.weight = weight;
            this.personalInfo.height = height;
            this.BMI = Math.round(Number(weight) / Math.pow((Number(height)/100), 2));
    
            if (this.BMI < 18.5) {
                this.status = 'underweight';
            }else if (this.BMI < 25) {
                this.status = 'normal';
            }else if (this.BMI < 30) {
                this.status = 'overweight';
            }else if (this.BMI >= 30) {
                this.status = 'obese';
                this.recommendation = 'admission required';
            }
        }
    }
    
    let person = new Person(input[0], input[1], input[2], input[3]);

    return person;
}

console.log(solve('Peter', 29, 75, 182));