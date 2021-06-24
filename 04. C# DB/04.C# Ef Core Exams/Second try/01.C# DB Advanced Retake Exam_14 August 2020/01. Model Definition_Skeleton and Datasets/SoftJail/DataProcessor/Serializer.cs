namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            //The given method in the project skeleton receives an array of prisoner ids.Export all prisoners that were processed which have these ids. For each prisoner, get their id, name, cell number they are placed in, their officers with each officer name, and the department name they are responsible for. At the end export the total officer salary with exactly two digits after the decimal place.Sort the officers by their name(ascending), sort the prisoners by their name(ascending), then by the prisoner id(ascending).

            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(x=>x.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = double.Parse(x.PrisonerOfficers.Select(o => o.Officer.Salary).Sum().ToString("F2"))
                })
                .OrderBy(x=>x.Name)
                .ThenBy(x=>x.Id)
                .ToList();

           return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            //Use the method provided in the project skeleton, which receives a string of comma - separated prisoner names. Export the prisoners: for each prisoner, export its id, name, incarcerationDate in the format “yyyy - MM - dd” and their encrypted mails.The encrypted algorithm you have to use is just to take each prisoner mail description and reverse it.Sort the prisoners by their name(ascending), then by their id(ascending).

            var splittedPrisoners = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var prisonersInboxDto = context.Prisoners
              .Where(x => splittedPrisoners.Contains(x.FullName))
              .Select(x => new PrisonersInboxXmlExportModel
              {
                  Id = x.Id,
                  FullName = x.FullName,
                  IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                  EncryptedMessages = x.Mails.Select(m => new EncryptedMessage {
                      Descripton = string.Join("", m.Description.Reverse())
                  })
                  .ToArray()
              })
              .OrderBy(x=>x.FullName)
              .ThenBy(x=>x.Id)
              .ToList();

            return XmlConverter.Serialize(prisonersInboxDto, "Prisoners");
        }
    }
}

//{
//    "Id": 3,
//    "Name": "Binni Cornhill",
//    "CellNumber": 503,
//    "Officers": [
//      {
//        "OfficerName": "Hailee Kennon",
//        "Department": "ArtificialIntelligence"
//      },
//      {
//        "OfficerName": "Theo Carde",
//        "Department": "Blockchain"
//      }
//    ],
//    "TotalOfficerSalary": 7127.93
//  },
