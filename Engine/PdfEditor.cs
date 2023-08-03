using System;
using System.Linq;
using System.Threading.Tasks;
using PdfEditor.Engine.Exceptions;
using PdfEditor.Engine.Options;
using PdfSharp.Pdf;

namespace PdfEditor.Engine;

internal sealed class PdfEditor : IPdfEditor
{
    public Task<PdfDocument> CutUntilAsync(CutUntilOptions options)
    {
        var source = options.Document;
        var pages = source.Pages;

        if (options.PageNumber > pages.Count)
            throw new PdfPagesSoLessException("Page number more than document has");

        var document = new PdfDocument();
        for (var i = 0; i < options.PageNumber; i++)
            document.AddPage(pages[i + 1]);

        return Task.FromResult(document);
    }

    public Task<PdfDocument> CutAfterAsync(CutAfterOptions options)
    {
        var source = options.Document;
        var pages = source.Pages;

        if (options.StartPage > pages.Count)
            throw new PdfPagesSoLessException("Start page more than document has");

        var document = new PdfDocument();
        for (var i = options.StartPage - 1; i < pages.Count; i++)
            document.AddPage(pages[i]);

        return Task.FromResult(document);
    }

    public Task<PdfDocument> CutPartAsync(CutPartOptions options)
    {
        var source = options.Document;
        var pages = source.Pages;

        if (options.StartPage > pages.Count)
            throw new PdfPagesSoLessException("Start page more than document has");

        var document = new PdfDocument();
        for (var i = 0; i < options.PagesCount; i++)
            document.AddPage(pages[options.StartPage + i]);

        return Task.FromResult(document);
    }

    public Task<PdfDocument> CutPagesAsync(CutPagesOptions options)
    {
        if (options.Numbers.Length < 1)
            throw new ArgumentException("Numbers count must be more 0");

        var source = options.Document;
        var pages = source.Pages;
        var set = options.Numbers.ToHashSet();

        if (set.Any(x => x > pages.Count))
            throw new PdfPagesSoLessException("Entered page number more than document has");

        var document = new PdfDocument();
        for (var i = 0; i < pages.Count; i++)
        {
            if (set.Contains(i + 1))
                continue;
            document.AddPage(pages[i]);
        }

        return Task.FromResult(document);
    }

    public Task<PdfDocument> CutPagesExceptAsync(CutPagesExceptOptions options)
    {
        if (options.Numbers.Length < 1)
            throw new ArgumentException("Numbers count must be more 0");

        var source = options.Document;
        var pages = source.Pages;
        var set = options.Numbers.ToHashSet();

        var document = new PdfDocument();
        for (var i = 0; i < pages.Count; i++)
        {
            if (set.Contains(i + 1))
                document.AddPage(pages[i]);
        }

        return Task.FromResult(document);
    }
}