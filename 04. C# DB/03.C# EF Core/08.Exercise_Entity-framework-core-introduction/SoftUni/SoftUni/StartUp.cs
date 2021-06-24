using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            Console.WriteLine(DeleteProjectById(db));
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .Include(x => x.Addresses)
                .FirstOrDefault(x => x.Name == "Seattle");

            var employees = context.Employees
                .Where(x => x.Address.Town == town);

            foreach (var employee in employees)
            {
                employee.Address = null;
            }

            var numOfAddresses = 0;
            foreach (var address in town.Addresses)
            {
                context.Remove(address);
                numOfAddresses++;
            }
            context.Remove(town);

            context.SaveChanges();
            return $"{numOfAddresses} addresses in Seattle were deleted";
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeeProjectsToDelete = context.EmployeesProjects
                .Where(x => x.ProjectId == 2);

            foreach (var proj in employeeProjectsToDelete)
            {
                context.EmployeesProjects.Remove(proj);
            }
            var projects = context.Projects
                .Take(10)
                .ToList();

            projects.Remove(projects.FirstOrDefault(x => x.ProjectId == 2));

            context.SaveChanges();

            projects = context.Projects
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }


            return sb.ToString().Trim();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().Trim();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            //Write a program that increase salaries of all employees that are in the Engineering, Tool Design, Marketing or Information Services department by 12%. Then return first name, last name and salary (2 symbols after the decimal separator) for those employees whose salary was increased. Order them by first name (ascending), then by last name (ascending). Format of the output.

            var employees = context.Employees
                .Include(x => x.Department)
                .Where(x => x.Department.Name == "Engineering"
                || x.Department.Name == "Tool Design"
                || x.Department.Name == "Marketing"
                || x.Department.Name == "Information Services")
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            context.SaveChanges();

            return sb.ToString().Trim();
        }
        //Write a program that return information about the last 10 started projects. Sort them by name lexicographically and
        //return their name, description and start date, each on a new row. Format of the output

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .ToList()
                .OrderBy(x=>x.Name);

            var sb = new StringBuilder();

            foreach (var proj in projects)
            {
                sb.AppendLine($"{proj.Name}");
                sb.AppendLine($"{proj.Description}");
                sb.AppendLine($"{proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }

            return sb.ToString().Trim();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {

            var departments = context.Departments
                .Include(x => x.Manager)
                .Include(x => x.Employees)
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

                foreach (var emp in department.Employees
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName))
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects
                        .OrderBy(p => p.Project.Name)
                        .Select(p => new { p.Project.Name })
                        .ToList()
                })
                .FirstOrDefault(x => x.EmployeeId == 147);

            var sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"{project.Name}");

            }

            return sb.ToString().Trim();

        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Select(x => new
                {
                    x.AddressText,
                    townName = x.Town.Name,
                    employeesCount = x.Employees.Count
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.townName} - {address.employeesCount} employees");
            }

            return sb.ToString().Trim();
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            var employees = context.Employees
                .Where(x => x.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    managerFirstName = x.Manager.FirstName,
                    managerLastName = x.Manager.LastName,
                    projects = x.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();


            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.managerFirstName} {employee.managerLastName}");

                foreach (var project in employee.projects)
                {
                    var projectEndDate = project.EndDate.HasValue ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";


                    sb.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {projectEndDate}");
                }
            }

            return sb.ToString().Trim();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 5
            };

            var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            nakov.Address = newAddress;

            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Select(x => new
                {
                    addressText = x.Address.AddressText
                })
                .Take(10);

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine(employee.addressText);
            }

            return sb.ToString().Trim();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    departmentName = x.Department.Name,
                    x.Salary
                })
                .ToList();


            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.departmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(x => x.FirstName)
                .Where(x => x.Salary > 50000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName:F2} - {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(x => x.EmployeeId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                var employeeStr = $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}";
                sb.AppendLine(employeeStr);
            }

            return sb.ToString().Trim();
        }
    }
}
