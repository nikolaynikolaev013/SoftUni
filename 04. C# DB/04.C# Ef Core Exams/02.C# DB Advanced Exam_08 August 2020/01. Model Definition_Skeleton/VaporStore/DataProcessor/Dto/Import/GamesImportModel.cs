using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class GamesImportModel
    {
        public GamesImportModel()
        {
        }

        [Required]
        public string Name { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}



//"Price": 0,
//		"ReleaseDate": "2013-07-09",
//		"Developer": "Valid Dev",
//		"Genre": "Valid Genre",
//		"Tags": [
//			"Valid Tag"
//		]
//	},
//	{
//	"Name": "Invalid",
//		"Price": -5,
//		"ReleaseDate": "2013-07-09",
//		"Developer": "Valid Dev",
//		"Genre": "Valid Genre",
//		"Tags": [
//			"Valid Tag"
//		]
//	},
//	{
//	"Name": "Invalid",
//		"Price": 0,
//		"ReleaseDate": "2013-07-09",
//		"Genre": "Valid Genre",
//		"Tags": [
//			"Valid Tag"
//		]
//	},