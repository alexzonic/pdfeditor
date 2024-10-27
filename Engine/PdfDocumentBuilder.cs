using System.IO;
using JetBrains.Annotations;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfEditor.Engine;

public sealed class PdfDocumentBuilder
{
    public PdfDocument FromFile([NotNull] string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }

        return PdfReader.Open(path, PdfDocumentOpenMode.Import);
    }

    public PdfDocument FromStream(Stream stream)
    {
        return PdfReader.Open(stream);
    }
}