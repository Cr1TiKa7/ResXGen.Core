using System.Xml.Serialization;

namespace ResXGen.Core.Models.ResXXml
{
    [XmlRoot(ElementName = "resheader")]
    public class Resheader
    {
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}