using System.IO;
using JetBrains.Annotations;
using PdfEditor.Engine.Exceptions;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfEditor.Engine;

public sealed class PdfDocumentBuilder
{
    public PdfDocument BuildFromFile([NotNull] string path)
    {
        if (!File.Exists(path))
        {
            throw new PdfNotFoundException(path);
        }

        return PdfReader.Open(path, PdfDocumentOpenMode.Import);
    }

    public PdfDocument BuildFromStream(Stream stream)
    {
        return PdfReader.Open(stream);
    }
}