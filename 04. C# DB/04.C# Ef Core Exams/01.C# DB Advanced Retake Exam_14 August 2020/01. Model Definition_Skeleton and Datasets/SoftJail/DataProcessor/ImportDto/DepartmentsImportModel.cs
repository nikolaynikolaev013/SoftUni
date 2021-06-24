using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentsImportModel
    {
        public DepartmentsImportModel()
        {
        }

        [StringLength(25, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public ICollection<CellImportModel> Cells { get; set; }
    }
}
//•	Id – integer, Primary Key
//•	Name – text with min length 3 and max length 25 (required)
//•	Cells - collection of type Cell

// {
//"Name": "",
//    "Cells": [
//      {
//        "CellNumber": 101,
//        "HasWindow": true
//      },
//      {
//    "CellNumber": 102,
//        "HasWindow": false
//      }
//    ]
//  },
//  {
//    "Name": "CSS",
//    "Cells": [
//      {
//        "CellNumber": 0,
//        "HasWindow": true
//      },
//      {
//        "CellNumber": 202,
//        "HasWindow": false
//      }
//    ]
//  },