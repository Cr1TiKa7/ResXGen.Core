using System.Xml.Serialization;

namespace ResXGen.Core.Models.ResXXml
{
    [XmlRoot(ElementName = "data")]
    public class Data
    {
        public Data() { }
        public Data(string name, string value, string comment)
        {
            Name = name;
            Value = value;
            Comment = comment;
        }
        public Data(string name, string value, ResXFileType fileType)
        {
            Name = name;
            Value = value;
            Type = "System.Resources.ResXFileRef, System.Windows.Forms";
        }

        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "comment")]
        public string Comment { get; set; }
        [XmlAttribute(AttributeName = "space", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Space { get; set; }
    }
}