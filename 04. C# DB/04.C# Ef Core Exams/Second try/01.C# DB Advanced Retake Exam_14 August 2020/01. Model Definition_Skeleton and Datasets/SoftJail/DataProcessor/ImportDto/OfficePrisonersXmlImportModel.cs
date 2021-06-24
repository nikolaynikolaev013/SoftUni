using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor.ImportDto
{
	[XmlType("Officer")]
    public class OfficePrisonersXmlImportModel
    {
        public OfficePrisonersXmlImportModel()
        {
        }

		[XmlElement("Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FullName { get; set; }

		[XmlElement("Money")]
        [Range(0, Double.MaxValue)]
        public decimal Salary { get; set; }

        [XmlElement("Position")]
        [EnumDataType(typeof(Position))]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [EnumDataType(typeof(Weapon))]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }


        [XmlArray("Prisoners")]
        public PrisionersXmlImportModel[] Prisoners { get; set; }
    }
}

//•	FullName – text with min length 3 and max length 30 (required)
//•	Salary – decimal(non - negative, minimum value: 0)(required)
//•	Position - Position enumeration with possible values: “Overseer, Guard, Watcher, Labour” (required)
//•	Weapon - Weapon enumeration with possible values: “Knife, FlashPulse, ChainRifle, Pistol, Sniper” (required)
//•	DepartmentId - integer, foreign key(required)
//•	Department – the officer's department (required)
//•	OfficerPrisoners - collection of type OfficerPrisoner


//< Officer >
//		< Name > Minerva Kitchingman </ Name >

//		   < Money > 2582 </ Money >

//		   < Position > Invalid </ Position >

//		   < Weapon > ChainRifle </ Weapon >

//		   < DepartmentId > 2 </ DepartmentId >

//		   < Prisoners >

//			   < Prisoner id = "15" />

//			</ Prisoners >

//		</ Officer >

//		< Officer >

//			< Name > Minerva Holl </ Name >

//			   < Money > 2582.55 </ Money >

//			   < Position > Overseer </ Position >

//			   < Weapon > ChainRifle </ Weapon >

//			   < DepartmentId > 2 </ DepartmentId >

//			   < Prisoners >

//				   < Prisoner id = "15" />

//				</ Prisoners >

//			</ Officer >