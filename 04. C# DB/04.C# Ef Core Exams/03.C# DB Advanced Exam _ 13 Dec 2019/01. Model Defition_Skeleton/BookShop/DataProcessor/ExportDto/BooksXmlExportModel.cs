using System;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class BooksXmlExportModel
    {
        public BooksXmlExportModel()
        {
        }
        [XmlAttribute("Pages")]
        public int Pages { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Date")]
        public string PublishedOn { get; set; }

    }
}

//< Book Pages = "4881" >
 
//     < Name > Sierra Marsh Fern</Name>
//        <Date>03/18/2016</Date>
//  </Book>
//  <Book Pages = "4786" >
    
//        < Name > Little Elephantshead</Name>
//        <Date>12/16/2014</Date>
//  </Book>
