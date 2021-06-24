using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchasesImportModel
    {
        public PurchasesImportModel()
        {
        }

        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [XmlElement("Type")]
        [Required]
        [EnumDataType(typeof(PurchaseType))]
        public string Type { get; set; }

        [XmlElement("Key")]
        [RegularExpression("^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        public string Key { get; set; }

        [XmlElement("Card")]
        [Required]
        [RegularExpression("^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Card { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }

    }
}

//< Purchases >
//  < Purchase title = "Dungeon Warfare 2" >
 
//     < Type > Digital </ Type >
 
//     < Key > ZTZ3 - 0D2S - G4TJ </ Key >
      
//          < Card > 1833 5024 0553 6211 </ Card >
         
//             < Date > 07 / 12 / 2016 05:49 </ Date >
                
//                  </ Purchase >
                
//                  < Purchase title = "The Crew 2" >
                 
//                     < Type > Retail </ Type >
                 
//                     < Key > DCU0 - S60G - NTQJ </ Key >
                 
//                     < Card > 5208 8381 5687 8508 </ Card >
                    
//                        < Date > 22 / 01 / 2017 09:33 </ Date >
                           
//                             </ Purchase >