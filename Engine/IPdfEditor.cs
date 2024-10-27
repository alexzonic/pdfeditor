using PdfEditor.Engine.Options;
using PdfSharp.Pdf;

namespace PdfEditor.Engine;

public interface IPdfEditor
{
    PdfDocument CutRange(CutRangesOptions options);
}