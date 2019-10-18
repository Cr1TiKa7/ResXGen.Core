using System;

namespace ResXGen.Core.Models
{
    internal class ResXFileTypeAttribute : Attribute
    {
        public string Prefix { get; set; }
    }
}
