using System.Threading.Tasks;
using PdfEditor.Engine;
using PdfEditor.Engine.Options;

namespace PdfEditor.ConsoleClient.Execution;

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
                return _pdfEditor.CutUntilAsync((CutUntilOptions) options);
            case Commands.CutAfter:
                return _pdfEditor.CutAfterAsync((CutAfterOptions) options);
            case Commands.CutPart:
                return _pdfEditor.CutPartAsync((CutPartOptions) options);
            case Commands.CutPages:
                return _pdfEditor.CutPagesAsync((CutPagesOptions) options);
            case Commands.CutAllPagesExcept:
                return _pdfEditor.CutPagesExceptAsync((CutPagesExceptOptions) options);
        }

        return Task.CompletedTask;
    }
}