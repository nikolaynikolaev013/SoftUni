namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            //Export all projects that have at least one task.For each project, export its name, tasks count, and if it has end(due) date which is represented like "Yes" and "No".
            //For each task, export its name and label type.Order the tasks by name(ascending).
            //Order the projects by tasks count(descending), then by name(ascending).
            //NOTE: You may need to call.ToArray() function before the selection in order to detach entities from the database and avoid runtime errors(EF Core bug).

            var projects = context.Projects
                .Where(x => x.Tasks.Count > 0)
                .ToArray()
                .Select(x => new ProjectWithTasksXmlExportModel {
                    ProjectName = x.Name,
                    TasksCount = x.Tasks.Count,
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(t => new TasksXmlExportModel {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t=>t.Name)
                    .ToArray()
                })
                .OrderByDescending(x=>x.TasksCount)
                .ThenBy(x=>x.ProjectName)
                .ToArray();

            return XmlConverter.Serialize(projects, "Projects");
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            //Select the top 10 employees who have at least one task that its open date is after or equal to the given date with their tasks that meet the same requirement(to have their open date after or equal to the giver date).For each employee, export their username and their tasks.
            //For each task, export its name and open date(must be in format "d"), due date(must be in format "d"), label and execution type.
            //Order the tasks by due date(descending), then by name(ascending).Order the employees by all tasks(meeting above condition) count(descending), then by username(ascending).

            var employees = context.Employees
                .Where(x => x.EmployeesTasks.Where(p => p.Task.OpenDate >= date).Count() > 0)
                .ToArray()
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks.Where(p => p.Task.OpenDate >= date)
                    .OrderByDescending(p => p.Task.DueDate)
                    .ThenBy(p => p.Task.Name)
                    .Select(p => new
                    {
                        TaskName = p.Task.Name,
                        OpenDate = p.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = p.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = p.Task.LabelType.ToString(),
                        ExecutionType = p.Task.ExecutionType.ToString()
                    })
                    .ToList()
                })
                .OrderByDescending(x => x.Tasks.Count)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}