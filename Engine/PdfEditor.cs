using System.Linq;
using PdfEditor.Core.Exceptions;
using PdfEditor.Engine.Options;
using PdfSharp.Pdf;

namespace PdfEditor.Engine;

internal sealed class PdfEditor : IPdfEditor
{
    public PdfDocument CutRange(CutRangesOptions options)
    {
        var pagesToAdd = options.Ranges.SelectMany(x => x).ToArray();
        var pagesToAddSet = pagesToAdd.ToHashSet();

        if (pagesToAdd.Any(x => x < 0))
            throw new InvalidArgumentException("Ranges has negative values");

        if (pagesToAdd.Length != pagesToAddSet.Count)
            throw new InvalidArgumentException("Ranges has intersections");

        var source = options.Document;
        var pages = source.Pages;

        if (pagesToAdd.Max() >= pages.Count)
            throw new InvalidArgumentException("Ranges has value greater than document pages count");

        var document = new PdfDocument();

        foreach (var page in pagesToAdd.Select(i => pages[i]))
        {
            document.AddPage(page);
        }

        return document;
    }
}