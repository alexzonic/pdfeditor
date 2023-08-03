using PdfSharp.Pdf;

namespace PdfEditor.Engine.Options;

public sealed record CutAfterOptions : IOptions
{
    public PdfDocument Document { get; }

    public int StartPage { get; }
}