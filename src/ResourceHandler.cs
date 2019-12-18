using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using ResXGen.Core.Models;
using ResXGen.Core.Models.ResXXml;

namespace ResXGen.Core
{
    public class ResourceHandler
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(ResXRoot));

        /// <summary>
        /// Reads the given .resx file.
        /// </summary>
        /// <param name="filePath">Path to the .resx file.</param>
        /// <returns>An object which represents the .resx file.</returns>
        public ResXFile ReadResXFile(string filePath) {
            if (!File.Exists(filePath)) throw new FileNotFoundException($"The file '{filePath}' does not exist. Please check your given path.");
            return ReadResXFile(File.OpenRead(filePath));
        }

        /// <summary>
        /// Reads .resx file from stream.
        /// </summary>
        /// <param name="file"><see cref="Stream"/> with .resx data.</param>
        /// <returns>An object which represents the .resx file.</returns>
        public ResXFile ReadResXFile(Stream file) {
            ResXFile ret;
            try
            {
                using (var streamReader = new StreamReader(file))
                {
                    var fileContent = _serializer.Deserialize(streamReader);
                    ret = new ResXFile((ResXRoot)fileContent);
                }
            }
            catch (Exception ex)
            {
                throw new SerializationException("There was an error while parsing the given resx file.",ex);
            }

            return ret;
        }

        /// <summary>
        /// Saves the resource file to the given path.
        /// </summary>
        /// <param name="resxFile">The resource file object.</param>
        /// <param name="filePath">The path where the resource file will be saved to.</param>
        public void SaveResXFile(ResXFile resxFile, string filePath) {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
        }
        
        /// <summary>
        /// Saves the resource file to the given path.
        /// </summary>
        /// <param name="resxFile">The resource file object.</param>
        /// <param name="file">The <see cref="Stream"/> where the resource data will be saved to.</param>
        public void SaveResXFile(ResXFile resxFile, Stream file) {
            if (resxFile == null) throw new ArgumentNullException(nameof(resxFile));
            if (file == null) throw new ArgumentNullException(nameof(file));

            using (var streamWriter = new StreamWriter(file))
            {
                _serializer.Serialize(streamWriter, resxFile.GetResXRoot());
            }
        }

        /// <summary>
        /// Creates a new resource file.
        /// </summary>
        /// <returns>An ResXFile object to work with.</returns>
        public ResXFile CreateResxFile()
        {
            var root = new ResXRoot();
            root.Resheader = new List<Resheader>();
            root.Resheader.Add(new Resheader {Name = "resmimetype",Value = "text/microsoft-resx" });
            root.Resheader.Add(new Resheader {Name = "version",Value = "2.0" });
            root.Resheader.Add(new Resheader {Name = "reader",Value = "System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" });
            root.Resheader.Add(new Resheader {Name = "writer",Value = "System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" });
            root.Assembly = new ResXAssembly
            {
                Name = "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                Alias = "System.Windows.Forms"
            };
            root.Data = new List<Data>();
            var ret = new ResXFile(root);

            return ret;
        }
    }
}
