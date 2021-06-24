namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            //•	If there are any validation errors for the project entity(such as invalid name or open date), do not import any part of the entity and append an error message to the method output.
            //•	If there are any validation errors for the task entity(such as invalid name, open or due date are missing, task open date is before project open date or task due date is after project due date), do not import it(only the task itself, not the whole project) and append an error message to the method output.


          var sb = new StringBuilder();

            var projectsDto = XmlConverter.Deserializer<ProjectsXmlImportModel>(xmlString, "Projects");
            var projects = new List<Project>();

            foreach (var project in projectsDto)
            {
                if (!IsValid(project))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var dueDate = new DateTime?();

                if (!String.IsNullOrEmpty(project.DueDate))
                {
                    dueDate = DateTime.ParseExact(project.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    dueDate = null;
                }

                var currProject = new Project
                {
                    Name = project.Name,
                    OpenDate = DateTime.ParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DueDate = dueDate
                };

                foreach (var task in project.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var taskOpenDate = DateTime.ParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (taskOpenDate < currProject.OpenDate ||
                        taskDueDate > currProject.DueDate)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var currTask = new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = Enum.Parse<ExecutionType>(task.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(task.LabelType)
                    };

                    currProject.Tasks.Add(currTask);
                }
                sb.AppendLine($"Successfully imported project - {currProject.Name} with {currProject.Tasks.Count} tasks.");
                projects.Add(currProject);
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();
            return sb.ToString().Trim();

        }

    public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            //•	If any validation errors occur(such as invalid username, email or phone), do not import any part of the entity and append an error message to the method output.
            //•	Take only the unique tasks.
            //•	If a task does not exist in the database, append an error message to the method output and continue with the next task.

            var sb = new StringBuilder();
            var employeesDto = JsonConvert.DeserializeObject<EmployeeJsonImportModel[]>(jsonString);
            var employeesToImport = new List<Employee>();

            var tasks = context.Tasks.Select(x=>x.Id).ToList();

            foreach (var employee in employeesDto)
            {
                if (!IsValid(employee) )
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var currEmployee = new Employee
                {
                    Username = employee.Username,
                    Email = employee.Email,
                    Phone = employee.Phone
                };

                foreach (var task in employee.Tasks)
                {
                    if (!tasks.Contains(task))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var currTask = context.Tasks.FirstOrDefault(x => x.Id == task);
                    var currEmployeeTask = new EmployeeTask
                    {
                        Task = currTask
                    };

                    currEmployee.EmployeesTasks.Add(currEmployeeTask);
                }
                sb.AppendLine($"Successfully imported employee - {currEmployee.Username} with {currEmployee.EmployeesTasks.Count} tasks.");
                employeesToImport.Add(currEmployee);
            }

            context.Employees.AddRange(employeesToImport);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}