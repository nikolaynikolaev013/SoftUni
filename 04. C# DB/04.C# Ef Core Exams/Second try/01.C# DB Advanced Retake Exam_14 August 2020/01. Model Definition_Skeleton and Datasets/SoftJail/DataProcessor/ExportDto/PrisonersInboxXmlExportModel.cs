﻿using System;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class PrisonersInboxXmlExportModel
    {
        public PrisonersInboxXmlExportModel()
        {
        }
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string FullName { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public EncryptedMessage[] EncryptedMessages { get; set; }
    }
}



//        < Prisoner >
//< Id > 3 </ Id >
//< Name > Binni Cornhill </ Name >

//   < IncarcerationDate > 1967 - 04 - 29 </ IncarcerationDate >

//   < EncryptedMessages >

//     < Message >

//       < Description > !? sdnasuoht evif - ytnewt rof deksa uoy ro orez artxe na ereht sI </ Description >

//           </ Message >

//         </ EncryptedMessages >

//       </ Prisoner >