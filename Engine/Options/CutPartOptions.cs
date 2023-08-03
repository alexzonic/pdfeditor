using PdfSharp.Pdf;

namespace PdfEditor.Engine.Options;

public sealed record CutPartOptions : IOptions
{
    public PdfDocument Document { get; }

    public int StartPage { get; }

    public int PagesCount { get; }
}