using System.Collections.Generic;
using System.Xml.Serialization;

namespace ResXGen.Core.Models.ResXXml
{
    [XmlRoot(ElementName = "root")]
        public class ResXRoot
        {
            [XmlElement(ElementName = "schema", Namespace = "http://www.w3.org/2001/XMLSchema")]
            public Schema Schema { get; set; }
            [XmlElement(ElementName = "resheader")]
            public List<Resheader> Resheader { get; set; }

            [XmlElement(ElementName = "assembly")]
            public ResXAssembly Assembly { get; set; }
        [XmlElement(ElementName = "data")]
            public List<Data> Data { get; set; }
        }
}
