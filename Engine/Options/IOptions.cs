using PdfSharp.Pdf;

namespace PdfEditor.Engine.Options;

public interface IOptions
{
    public PdfDocument Document { get; }
}