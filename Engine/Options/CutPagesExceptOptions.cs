using PdfSharp.Pdf;

namespace PdfEditor.Engine.Options;

public sealed record CutPagesExceptOptions : IOptions
{
    public PdfDocument Document { get; }

    public int[] Numbers { get; }
}