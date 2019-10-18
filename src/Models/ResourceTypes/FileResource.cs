using System;
using System.Collections.Generic;
using System.Text;

namespace ResXGen.Core.Models.ResourceTypes
{
    public class FileResource
    {
        private string _name;
        private string _value;
        private string _type;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Value
        {
            get => _value;
            set => _value = value;
        }
        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public FileResource(string name, string value, string type)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _value = value ?? throw new ArgumentNullException(nameof(value));
            _type = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}
