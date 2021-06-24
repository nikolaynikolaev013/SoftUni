class Company{
   constructor(){
      this.departments = [];
   }

   addEmployee(username, salary, position, department){
      if (!username || !position || !department) {
         throw new Error("Invalid input!");
      }
      else if (salary < 0){
         throw new Error(" Invalid input!");
      }

      if (!this.departments[department]) {
         this.departments[department] = [];
      }
      
      this.departments[department].push({username, salary, position});

      console.log(`New employee is hired. Name: ${username}. Position: ${position}`);
   }

   bestDepartment(){
      let departments = {};

      Object.entries(this.departments).forEach(([department, employees]) => {
         let totalSalary = employees.map(e=>e.salary).reduce((acc, curr) => acc += curr);
         departments[department] = totalSalary / employees.length;
         console.log(departments[department]);
      });

      let maxSalary;

      Object.entries(departments).forEach(([department, totalSalary])=>{
         if (totalSalary < maxSalary) {
            maxSalary = totalSalary;
         }
      })
   }
}

function solve(){
   let c = new Company();
   c.addEmployee("Stanimir", 2000, "engineer", "Construction");
   c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
   c.addEmployee("Slavi", 500, "dyer", "Construction");
   c.addEmployee("Stan", 2000, "architect", "Construction");
   c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
   c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
   c.addEmployee("Gosho", 1350, "HR", "Human resources");
   c.bestDepartment();
}

solve();