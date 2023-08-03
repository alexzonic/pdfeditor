using PdfSharp.Pdf;

namespace PdfEditor.Engine.Options;

public sealed record CutUntilOptions : IOptions
{
    public PdfDocument Document { get; }

    public int PageNumber { get; }
}