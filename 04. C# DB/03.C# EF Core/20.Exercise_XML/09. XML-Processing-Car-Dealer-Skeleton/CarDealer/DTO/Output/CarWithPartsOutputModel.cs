using System;
using System.Xml.Serialization;

namespace CarDealer.DTO.Output
{
    [XmlType("car")]
    public class CarWithPartsOutputModel
    {
        public CarWithPartsOutputModel()
        {
        }

        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartOutputModel[] Parts { get; set; }
    }
}