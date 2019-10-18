using System.Xml.Serialization;

namespace ResXGen.Core.Models.ResXXml
{
    [XmlRoot(ElementName = "schema", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Schema
    {
        [XmlElement(ElementName = "import", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Import Import { get; set; }
        [XmlElement(ElementName = "element", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Element Element { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
        [XmlAttribute(AttributeName = "msdata", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Msdata { get; set; }
    }
}