using System.Collections.Generic;
using System.Xml.Serialization;

namespace ResXGen.Core.Models.ResXXml
{
    [XmlRoot(ElementName = "choice", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class Choice
    {
        [XmlElement(ElementName = "element", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public List<Element> Element { get; set; }
        [XmlAttribute(AttributeName = "maxOccurs")]
        public string MaxOccurs { get; set; }
    }
}