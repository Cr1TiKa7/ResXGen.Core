using System.Xml.Serialization;

namespace ResXGen.Core.Models.ResXXml
{
    [XmlRoot(ElementName = "import", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Import
    {
        [XmlAttribute(AttributeName = "namespace")]
        public string Namespace { get; set; }
    }
}