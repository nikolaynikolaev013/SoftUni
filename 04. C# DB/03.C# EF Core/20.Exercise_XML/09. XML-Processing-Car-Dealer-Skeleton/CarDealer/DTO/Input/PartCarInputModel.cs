﻿using System.Xml.Serialization;

namespace CarDealer.DTO.Input
{
    [XmlType("partId")]
    public class PartCarInputModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}