using System.Xml.Serialization;

namespace ResXGen.Core.Models.ResXXml
{
    [XmlRoot(ElementName = "attribute", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Attribute
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "use")]
        public string Use { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "ref")]
        public string Ref { get; set; }
        [XmlAttribute(AttributeName = "Ordinal", Namespace = "urn:schemas-microsoft-com:xml-msdata")]
        public string Ordinal { get; set; }
    }
}