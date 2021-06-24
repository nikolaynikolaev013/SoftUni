using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeeJsonImportModel
    {
        public EmployeeJsonImportModel()
        {
            this.Tasks = new HashSet<int>();
        }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"[A-z]+[0-9]*")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}")]
        public string Phone { get; set; }

        public ICollection<int> Tasks { get; set; }
    }
}

//•	Id - integer, Primary Key
//•	Username - text with length [3, 40]. Should contain only lower or upper case letters and/or digits. (required)
//•	Email – text(required).Validate it! There is attribute for this job.
//•	Phone - text.Consists only of three groups(separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required)
//•	EmployeesTasks - collection of type EmployeeTask

//{
//    "Username": "jstanett0",
//    "Email": "kknapper0@opera.com",
//    "Phone": "819-699-1096",
//    "Tasks": [
//      34,
//      32,
//      65,
//      30,
//      30,
//      45,
//      36,
//      67
//    ]
//  },
//  {
//    "Username": "mmcellen1",
//    "Email": "emorten1@ucla.edu",
//    "Phone": "806-478-7549",
//    "Tasks": [
//      30,
//      4,
//      13,
//      64,
//      5,
//      27,
//      6,
//      20,
//      20,
//      73,
//      31,
//      35,
//      44,
//      49,
//      37,
//      63,
//      1,
//      68,
//      15,
//      2
//    ]
//  },