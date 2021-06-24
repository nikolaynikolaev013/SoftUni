using System;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentsCellsJsonImportObject
    {
        public DepartmentsCellsJsonImportObject()
        {
        }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }
        public CellJsonImportModel[] Cells { get; set; }
    }
}


//•	Name – text with min length 3 and max length 25 (required)

//{
//    "Name": "",
//    "Cells": [
//      {
//        "CellNumber": 101,
//        "HasWindow": true
//      },
//      {
//        "CellNumber": 102,
//        "HasWindow": false
//      }
//    ]
//  },