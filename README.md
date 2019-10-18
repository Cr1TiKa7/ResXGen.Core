# ResXGen.Core

ResXGen is a simple library to manage .resx files.
It allows you to create, read and write .resx files.

> Compatible to every framework that supports .net standard 2.0

### Class ResXFile functions/methods

- AddStringResource(StringResource) : void | Adds or updates a string of the .resx file
- GetStringResources() : IEnumerable<StringResource> | Gets all available strings
- AddFileResource(string, ResXFileType, string) : void | Adds or updates a file of the .resx file. Also copies it to the given directory.
- AddFileResource(string, ResXFileType) : void | Adds or updates a file of the .resx file. Doesn't copy the file!
- GetFileResources() : IEnumerable<FileResource> | Gets all available files.

> Resources will be updated if the string name or file name already exists.
### Usage

To create a new .resx file:
``` csharp
var resourceHandler = new ResourceHandler();
var resxFile = resourceHandler.CreateResxFile();

// To add strings to your resouce file
resxFile.AddStringResource(new StringResource("STRING_NAME", "STRING_VALUE", "STRING_COMMENT"));
// To add files to your resouce file
resxFile.AddFileResource("PATH_TO_FILE", ResXFileType.Text);

resourceHandler.SaveResXFile(resxFile, "PATH_TO_RESX_FILE"); 
```

To read and write to an existing .resx file:
 ``` csharp
var resourceHandler = new ResourceHandler();
var resxFile = resourceHandler.ReadResXFile("./Resource.en-US.resx");

// To get available strings
var stringResources = resxFile.GetStringResources();
// To get available files
var fileResources = resxFile.GetFileResources();

resourceHandler.SaveResXFile(resxFile, $"./Resource.en-US.resx");
 ```

> Feel free to report any bugs or improvements.
