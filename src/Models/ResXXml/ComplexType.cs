using System.Collections.Generic;
using System.Xml.Serialization;

namespace ResXGen.Core.Models.ResXXml
{
    [XmlRoot(ElementName = "complexType", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class ComplexType
    {
        [XmlElement(ElementName = "sequence", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public Sequence Sequence { get; set; }
        [XmlElement(ElementName = "attribute", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public List<Attribute> Attribute { get; set; }
    }
}