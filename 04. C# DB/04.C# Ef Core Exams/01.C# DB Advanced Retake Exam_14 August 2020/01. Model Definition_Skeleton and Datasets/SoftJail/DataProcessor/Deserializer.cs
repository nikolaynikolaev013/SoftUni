namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
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
            var config = new MapperConfiguration(x => {
                x.AddProfile<SoftJailProfile>();
            });

            IMapper mapper = new Mapper(config);

            var sb = new StringBuilder();

            var departmentsCells = JsonConvert.DeserializeObject<IEnumerable<DepartmentsImportModel>>(jsonString);

            //•	If any validation errors occur(such as if a department name is too long/ short or a cell number is out of range) proceed as described above
            //•	If a department is invalid, do not import its cells.
            //•	If a Department doesn’t have any Cells, he is invalid.
            //•	If one Cell has invalid CellNumber, don’t import the Department.

            var departments = new List<Department>();

            foreach (var department in departmentsCells)
            {
                if (!IsValid(department)
                    || !department.Cells.Any()
                    || !department.Cells.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var newDepartment = new Department
                {
                    Name = department.Name,
                    Cells = department.Cells.Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    })
                    .ToList()
                };

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                departments.Add(newDepartment);
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            //•	The release and incarceration dates will be in the format “dd / MM / yyyy”. Make sure you use CultureInfo.InvariantCulture.
            //•	If any validation errors occur(such as invalid prisoner name or invalid nickname), ignore the entity and print an error message.
            //•	If a mail has incorrect address print error message and do not import the prisoner and his mails

            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<SoftJailProfile>();
            });
            IMapper mapper = new Mapper(config);

            var sb = new StringBuilder();
            var prisoners = new List<Prisoner>();

            var prisonerMails = JsonConvert.DeserializeObject<IEnumerable<PrisonerMailsImportModel>>(jsonString);

            foreach (var prisoner in prisonerMails)
            {
                if (!IsValid(prisoner) ||
                    !prisoner.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime.TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate);

                var newPrisoner = new Prisoner
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.NickName,
                    Age = prisoner.Age,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,
                    IncarcerationDate = DateTime.ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = releaseDate,
                    Mails = prisoner.Mails.Select(x=>new Mail {
                        Description = x.Description,
                        Sender = x.Sender,
                        Address = x.Address
                    }).ToList()
                };

                prisoners.Add(newPrisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().Trim();

        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var officersPrisonersDto = XmlConverter.Deserializer<OfficerPrisonerImportModel>(xmlString, "Officers");

            var officers = new List<Officer>();

            foreach (var officer in officersPrisonersDto)
            {
                if (!IsValid(officer))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                var currOfficer = new Officer()
                {
                    FullName = officer.Name,
                    Salary = officer.Salary,
                    Position = Enum.Parse<Position>(officer.Position),
                    Weapon = Enum.Parse<Weapon>(officer.Weapon),
                    DepartmentId = officer.DepartmentId,
                    OfficerPrisoners = officer.OfficerPrisoners.Select(x => new OfficerPrisoner
                    {
                        PrisonerId = x.PrisonerId
                    }).ToList()
                };

                officers.Add(currOfficer);
                sb.AppendLine($"Imported {officer.Name} ({officer.OfficerPrisoners.Count()} prisoners)");
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