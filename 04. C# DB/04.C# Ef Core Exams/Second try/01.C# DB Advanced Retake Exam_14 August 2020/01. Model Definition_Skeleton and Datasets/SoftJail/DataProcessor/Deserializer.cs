namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsCellsDto = JsonConvert.DeserializeObject<DepartmentsCellsJsonImportObject[]>(jsonString);
            var sb = new StringBuilder();
            var departments = new List<Department>();


            foreach (var departmentCell in departmentsCellsDto)
            {
                if (!IsValid(departmentCell) ||
                    !departmentCell.Cells.All(IsValid) ||
                    !departmentCell.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var currDepartment = new Department
                {
                    Name = departmentCell.Name
                };

                foreach (var cell in departmentCell.Cells)
                {
                    var currCell = new Cell
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow
                    };

                    currDepartment.Cells.Add(currCell);
                }

                sb.AppendLine($"Imported {currDepartment.Name} with {currDepartment.Cells.Count} cells");
                departments.Add(currDepartment);
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var prisonersMailsDto = JsonConvert.DeserializeObject<PrisonersMailsJsonImportModel[]>(jsonString);
            var prisoners = new List<Prisoner>();

            foreach (var prisonerMail in prisonersMailsDto)
            {

                if (!IsValid(prisonerMail) ||
                    !prisonerMail.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime.TryParseExact(prisonerMail.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate);

                var currPrisoner = new Prisoner
                {
                    FullName = prisonerMail.FullName,
                    Nickname = prisonerMail.Nickname,
                    Age = prisonerMail.Age,
                    Bail = prisonerMail.Bail,
                    CellId = prisonerMail.CellId,
                    IncarcerationDate = DateTime.ParseExact(prisonerMail.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ReleaseDate = releaseDate
                };

                foreach (var mail in prisonerMail.Mails)
                {
                    var currMail = new Mail
                    {
                        Address = mail.Address,
                        Description = mail.Description,
                        Sender = mail.Sender
                    };

                    currPrisoner.Mails.Add(currMail);
                }

                sb.AppendLine($"Imported {currPrisoner.FullName} {currPrisoner.Age} years old");
                prisoners.Add(currPrisoner);
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var officersPrisonersDto = XmlConverter.Deserializer<OfficePrisonersXmlImportModel>(xmlString, "Officers");
            var officers = new List<Officer>();

            foreach (var officer in officersPrisonersDto)
            {
                if (!IsValid(officer))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var currOfficer = new Officer
                {
                    FullName = officer.FullName,
                    Salary = officer.Salary,
                    Position = Enum.Parse<Position>(officer.Position),
                    Weapon = Enum.Parse<Weapon>(officer.Weapon),
                    DepartmentId = officer.DepartmentId
                };

                foreach (var prisoner in officer.Prisoners)
                {
                    var prisonerFromDb = context.Prisoners.FirstOrDefault(x => x.Id == prisoner.Id);

                    currOfficer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        Prisoner = prisonerFromDb
                    });
                }

                sb.AppendLine($"Imported {currOfficer.FullName} ({currOfficer.OfficerPrisoners.Count()} prisoners)");
                officers.Add(currOfficer);
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}