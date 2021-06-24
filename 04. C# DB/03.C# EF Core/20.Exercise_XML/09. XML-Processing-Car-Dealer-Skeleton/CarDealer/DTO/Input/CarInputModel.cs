using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.DTO.Input
{
    [XmlType("Car")]
    public class CarInputModel
    {
        public CarInputModel()
        {
        }

        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartCarInputModel[] Parts { get; set; }
    }
}
