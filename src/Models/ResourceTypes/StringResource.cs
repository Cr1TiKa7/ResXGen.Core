using System;

namespace ResXGen.Core.Models.ResourceTypes
{
    public class StringResource
    {
        private string _name;
        private string _value;
        private string _comment;
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
        public string Comment
        {
            get => _comment;
            set => _comment = value;
        }

        public StringResource(string name, string value, string comment = "")
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _value = value ?? throw new ArgumentNullException(nameof(value));
            _comment = comment;
        }
    }
}