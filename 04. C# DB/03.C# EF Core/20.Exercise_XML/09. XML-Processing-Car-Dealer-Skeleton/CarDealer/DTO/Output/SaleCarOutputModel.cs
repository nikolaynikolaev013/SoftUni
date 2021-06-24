﻿using System;
using System.Xml.Serialization;

namespace CarDealer.DTO.Output
{
    [XmlType("car")]
    public class SaleCarOutputModel
    {
        public SaleCarOutputModel()
        {
        }

        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
