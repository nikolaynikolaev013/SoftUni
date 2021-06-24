using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerPrisonerImportModel
    {
        public OfficerPrisonerImportModel()
        {
        }

        [Required]
        [XmlElement("Name")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [XmlElement("Money")]
        public decimal Salary { get; set; }

        [EnumDataType(typeof(Position))]
        [XmlElement("Position")]
        public string Position { get; set; }


        [EnumDataType(typeof(Weapon))]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }


        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonerIdImportModel[] OfficerPrisoners { get; set; }
    }
}
 
//•	Position - Position enumeration with possible values: “Overseer, Guard, Watcher, Labour” (required)
//•	Weapon - Weapon enumeration with possible values: “Knife, FlashPulse, ChainRifle, Pistol, Sniper” (required)
//•	DepartmentId - integer, foreign key(required)
//•	Department – the officer's department (required)
//•	OfficerPrisoners - collection of type OfficerPrisoner
