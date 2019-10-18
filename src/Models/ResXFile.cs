using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using ResXGen.Core.Models.ResourceTypes;
using ResXGen.Core.Models.ResXXml;

namespace ResXGen.Core.Models
{
    public class ResXFile
    {
        private readonly ResXRoot _resxRoot;
        internal ResXFile(ResXRoot resxRoot)
        {
            _resxRoot = resxRoot;
        }

        internal ResXRoot GetResXRoot()
        {
            return _resxRoot;
        }

        #region StringResource
        /// <summary>
        /// Adds a string resource to the resource file.
        /// </summary>
        /// <param name="stringResource">The object which contains the name, value and comment for the string resource.</param>
        public void AddStringResource(StringResource stringResource)
        {
            if (stringResource == null) throw new ArgumentNullException(nameof(stringResource));

            var existingIndex = _resxRoot.Data.FindIndex(x =>
                x.Name.Equals(stringResource.Name, StringComparison.OrdinalIgnoreCase));
            if (existingIndex < 0)
                _resxRoot.Data.Add(new Data(stringResource.Name,stringResource.Value,stringResource.Comment));
            else
                _resxRoot.Data[existingIndex] = new Data(stringResource.Name,stringResource.Value,stringResource.Comment);
        }

        /// <summary>
        /// Returns all available string resources.
        /// </summary>
        /// <returns>An enumerable which contains all string resources as an StringResource object.</returns>
        public IEnumerable<StringResource> GetStringResources()
        {
            var ret = new List<StringResource>();

            foreach (var data in _resxRoot.Data)
            {
                if (data.Space.Equals("preserve"))
                    ret.Add(new StringResource(data.Name, data.Value, data.Comment));
            }
            return ret;
        }
        #endregion

        #region Fileresources
        
        /// <summary>
        /// Adds a new file to the resource file.
        /// </summary>
        /// <param name="pathToFile">Path to the file.</param>
        /// <param name="fileType">The file type.</param>
        /// <param name="destinationDirectory">The directory where the file will be copied to.</param>
        public void AddFileResource(string pathToFile, ResXFileType fileType, string destinationDirectory)
        {
            if (!File.Exists(pathToFile)) throw new FileNotFoundException();

            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathToFile);
            var fileName = Path.GetFileName(pathToFile);
            var fileTypePrefix = GetPrefixByFileType(fileType);
            var newFilePath = Path.Combine(destinationDirectory, fileName);
            var dataValue = newFilePath + fileTypePrefix;

            if (!newFilePath.Equals(pathToFile)) 
                File.Copy(pathToFile,newFilePath);

            _resxRoot.Data.Add(new Data(fileNameWithoutExtension, dataValue, fileType));
        }

        /// <summary>
        /// Adds a new file to the resource file.
        /// </summary>
        /// <param name="pathToFile">Path to the file.</param>
        /// <param name="fileType">The file type.</param>
        public void AddFileResource(string pathToFile, ResXFileType fileType)
        {
            AddFileResource(pathToFile,fileType, Path.GetDirectoryName(pathToFile));
        }

        /// <summary>
        /// Gets every available file resource.
        /// </summary>
        /// <returns>An enumerable which contains all file resources as an FileResource object.</returns>
        public IEnumerable<FileResource> GetFileResources()
        {
            var ret = new List<FileResource>();

            foreach (var data in _resxRoot.Data)
            {
                if (!data.Space.Equals("preserve"))
                    ret.Add(new FileResource(data.Name, data.Value, data.Type));
            }
            return ret;
        }
        #endregion

        #region Helper
        private string GetPrefixByFileType(ResXFileType fileType)
        {
            var ret = "";
            var enumType = typeof(ResXFileType);
            var memberInfos = enumType.GetMember(fileType.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes =
                enumValueMemberInfo.GetCustomAttributes(typeof(ResXFileTypeAttribute), false);

            foreach (var attribute in valueAttributes)
            {
                if (attribute is ResXFileTypeAttribute resxFileAttribute)
                    ret = resxFileAttribute.Prefix;
            }

            return ret;
        }
        #endregion
    }
}
