using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class CellJsonImportModel
    {
        [Range(1, 1000)]
        public int CellNumber { get; set; }
        public bool HasWindow { get; set; }
    }
}


//•	CellNumber – integer in the range [1, 1000] (required)
//•	HasWindow – bool(required)

//        "CellNumber": 101,
//        "HasWindow": true