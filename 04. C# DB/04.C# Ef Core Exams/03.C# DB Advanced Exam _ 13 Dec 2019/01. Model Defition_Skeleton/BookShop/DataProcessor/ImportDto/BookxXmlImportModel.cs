using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using BookShop.Data.Models;
using BookShop.Data.Models.Enums;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class BookxXmlImportModel
    {
        public BookxXmlImportModel()
        {
        }

        [XmlElement("Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [XmlElement("Genre")]
        [EnumDataType(typeof(Genre))]
        public int Genre { get; set; }

        [XmlElement("Price")]
        [Range(0.01, Double.MaxValue)]
        public decimal? Price { get; set; }

        [XmlElement("Pages")]
        [Range(50, 5000)]
        public int? Pages { get; set; }

        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; }

    }
}

//< Books >
//  < Book >
//    < Name > Hairy Torchwood </ Name >
   
//       < Genre > 3 </ Genre >
   
//       < Price > 41.99 </ Price >
   
//       < Pages > 3013 </ Pages >
   
//       < PublishedOn > 01 / 13 / 2013 </ PublishedOn >
   
//     </ Book >

//•	Name - text with length [3, 30]. (required)
//•	Genre - enumeration of type Genre, with possible values (Biography = 1, Business = 2, Science = 3) (required)
//•	Price - decimal in range between 0.01 and max value of the decimal
//•	Pages – integer in range between 50 and 5000
//•	PublishedOn - date and time (required)
//•	AuthorsBooks - collection of type AuthorBook
