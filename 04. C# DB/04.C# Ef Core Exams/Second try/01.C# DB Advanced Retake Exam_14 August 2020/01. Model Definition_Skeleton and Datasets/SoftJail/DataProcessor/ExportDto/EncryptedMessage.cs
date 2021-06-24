using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class EncryptedMessage
    {
        [XmlElement("Description")]
        public string Descripton { get; set; }
    }
}
