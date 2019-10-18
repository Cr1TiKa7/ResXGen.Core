using System.Xml.Serialization;

namespace ResXGen.Core.Models.ResXXml
{
    [XmlRoot(ElementName = "element", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Element
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "minOccurs")]
        public string MinOccurs { get; set; }
        [XmlElement(ElementName = "complexType", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public ComplexType ComplexType { get; set; }
    }
}