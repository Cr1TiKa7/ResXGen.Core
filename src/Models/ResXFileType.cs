namespace ResXGen.Core.Models
{
    public enum ResXFileType
    {
        [ResXFileType(Prefix = ";System.IO.MemoryStream, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
        Audio,
        [ResXFileType(Prefix = ";System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
        Picture,
        [ResXFileType(Prefix = ";System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;Windows-1252")]
        Text,
        [ResXFileType(Prefix = ";System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
        Other
    }
}
