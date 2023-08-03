using System.Linq;

namespace PdfEditor
{
    internal sealed class PdfEditorPathSplitter
    {
        public (string path, string fileName, bool fileContainPdfExtension) SplitPath(string sourceFilePath)
        {
            var pathParts = sourceFilePath.Split('\\');

            var path = string.Join("\\", pathParts.Take(pathParts.Length - 1));
            var fileName = pathParts.Last();
            var fileContainPdfExtension = fileName.Contains(".pdf");

            return (path, fileName, fileContainPdfExtension);
        }
    }
}