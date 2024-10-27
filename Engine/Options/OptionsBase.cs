using PdfSharp.Pdf;

namespace PdfEditor.Engine.Options;

public abstract record OptionsBase
{
    public PdfDocument Document { get; init; }
}