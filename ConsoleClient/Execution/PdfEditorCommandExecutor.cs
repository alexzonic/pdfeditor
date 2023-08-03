using System.Threading.Tasks;
using PdfEditor;
using PdfEditor.Options;

namespace ConsoleClient.Execution
{
    internal sealed class PdfEditorCommandExecutor : IPdfEditorCommandExecutor
    {
        private readonly IPdfEditor _pdfEditor;

        public PdfEditorCommandExecutor(IPdfEditor pdfEditor)
        {
            _pdfEditor = pdfEditor;
        }

        public Task Execute(string command, object options)
        {
            switch (command)
            {
                case Commands.Help:

                    break;
                case Commands.CutUntil:
                    return _pdfEditor.CutDocumentUntil((CutDocumentUntilOptions) options);
                case Commands.CutAfter:
                    return _pdfEditor.CutDocumentAfter((CutDocumentAfterOptions) options);
                case Commands.CutPart:
                    return _pdfEditor.CutDocumentPart((CutDocumentPartOptions) options);
                case Commands.CutPages:
                    return _pdfEditor.CutDocumentPages((CutDocumentPagesOptions) options);
                case Commands.CutAllPagesExcept:
                    return _pdfEditor.CutAllDocumentPagesExcept((CutAllDocumentPagesExceptOptions) options);
            }

            return Task.CompletedTask;
        }
    }
}