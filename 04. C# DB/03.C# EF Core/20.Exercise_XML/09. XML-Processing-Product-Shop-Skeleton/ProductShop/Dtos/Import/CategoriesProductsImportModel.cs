using System;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("CategoryProduct")]
    public class CategoriesProductsImportModel
    {
        public CategoriesProductsImportModel()
        {
        }

        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement("ProductId")]
        public int ProductId { get; set; }

    }
}
