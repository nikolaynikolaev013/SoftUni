using System;
using System.Xml.Serialization;

namespace CarDealer.DTO.Input
{
    [XmlType("Sale")]
    public class SaleInputModel
    {
        public SaleInputModel()
        {
        }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }
    }
}
