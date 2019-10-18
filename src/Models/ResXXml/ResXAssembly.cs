using System.Xml.Serialization;

namespace ResXGen.Core.Models.ResXXml
{
    [XmlRoot(ElementName = "attribute", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class ResXAssembly
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "alias")]
        public string Alias { get; set; }
    }
}