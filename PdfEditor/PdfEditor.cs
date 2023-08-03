using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PdfEditor.Exceptions;
using PdfEditor.Options;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfEditor
{
    public sealed class PdfEditor : IPdfEditor
    {
        private readonly string _sourceFilePath;
        private readonly string _path;
        private readonly string _sourceFileName;
        private readonly string _editedFileName;
        private readonly string _editedFilePath;
        private readonly bool _sourceFileContainPdfExtension;
        private readonly PdfEditorPathSplitter _pathSplitter = new PdfEditorPathSplitter();

        private PdfDocument PdfDocument => TryOpenDocument(_sourceFilePath);

        public PdfEditor(string sourceFilePath, string editedFileName)
        {
            _sourceFilePath = sourceFilePath;

            var (path, fileName, fileContainPdfExtension) = _pathSplitter.SplitPath(sourceFilePath);
            _path = path;
            _sourceFileName = fileName;
            _sourceFileContainPdfExtension = fileContainPdfExtension;

            var extension = fileContainPdfExtension ? string.Empty : ".pdf";
            _editedFileName = editedFileName ?? $"{fileName}{extension}";
            _editedFilePath = $@"{path}\updated_{_editedFileName}";
        }

        public Task CutDocumentUntil(CutDocumentUntilOptions options)
        {
            var source = PdfDocument;
            var pages = source.Pages;

            if (options.PageNumber > pages.Count)
                throw new PdfPagesSoLessException("Page number more than document has");

            var document = new PdfDocument();
            for (var i = 0; i < options.PageNumber; i++)
                document.AddPage(pages[i + 1]);

            return SaveAsync(document);
        }

        public Task CutDocumentAfter(CutDocumentAfterOptions options)
        {
            var source = PdfDocument;
            var pages = source.Pages;

            if (options.StartPage > pages.Count)
                throw new PdfPagesSoLessException("Start page more than document has");

            var document = new PdfDocument();
            for (var i = options.StartPage - 1; i < pages.Count; i++)
                document.AddPage(pages[i]);

            return SaveAsync(document);
        }

        public Task CutDocumentPart(CutDocumentPartOptions options)
        {
            var source = PdfDocument;
            var pages = source.Pages;

            if (options.StartPage > pages.Count)
                throw new PdfPagesSoLessException("Start page more than document has");

            var document = new PdfDocument();
            for (var i = 0; i < options.PagesCount; i++)
                document.AddPage(pages[options.StartPage + i]);

            return SaveAsync(document);
        }

        public Task CutDocumentPages(CutDocumentPagesOptions options)
        {
            if (options.Numbers.Length < 1)
                throw new ArgumentException("Numbers count must be more 0");

            var source = PdfDocument;
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

            return SaveAsync(document);
        }

        public Task CutAllDocumentPagesExcept(CutAllDocumentPagesExceptOptions options)
        {
            if (options.Numbers.Length < 1)
                throw new ArgumentException("Numbers count must be more 0");

            var source = PdfDocument;
            var pages = source.Pages;
            var set = options.Numbers.ToHashSet();

            var document = new PdfDocument();
            for (var i = 0; i < pages.Count; i++)
            {
                if (set.Contains(i + 1))
                    document.AddPage(pages[i]);
            }

            return SaveAsync(document);
        }

        private static PdfDocument TryOpenDocument(string path)
        {
            if (!File.Exists(path))
            {
                throw new PdfNotFoundException(path);
            }

            return PdfReader.Open(path, PdfDocumentOpenMode.Import);
        }

        private Task SaveAsync(PdfDocument document) => Task.Run(() =>
        {
            document.Save(_editedFilePath);
            document.Dispose();
        });
    }
}