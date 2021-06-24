using System;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("Category")]
    public class CategoriesImportModel
    {
        public CategoriesImportModel()
        {
        }

        [XmlElement("name")]
        public string Name { get; set; }
    }
}
