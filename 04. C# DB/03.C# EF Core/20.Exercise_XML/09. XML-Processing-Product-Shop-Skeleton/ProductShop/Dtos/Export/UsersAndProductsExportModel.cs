using System;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class UsersAndProductsExportModel
    {
        public UsersAndProductsExportModel()
        {
        }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UsersExportModel[] Users { get; set; }
    }
}
