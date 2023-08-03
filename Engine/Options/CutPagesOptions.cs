using PdfSharp.Pdf;

namespace PdfEditor.Engine.Options;

public sealed record CutPagesOptions : IOptions
{
    public PdfDocument Document { get; }

    public int[] Numbers { get; }
}