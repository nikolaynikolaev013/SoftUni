using System;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class SoldProductsExportModel
    {
        public SoldProductsExportModel()
        {
        }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ProductsExportModel[] SoldProducts { get; set; }
    }
}
