using System;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class UsersExportModel
    {
        public UsersExportModel()
        {
        }

        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public SoldProductsExportModel Products { get; set; }

    }
}
