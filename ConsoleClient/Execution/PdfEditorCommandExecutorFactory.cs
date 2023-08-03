using PdfEditor.Engine;

namespace PdfEditor.ConsoleClient.Execution;

internal static class PdfEditorCommandExecutorFactory
{
    public static IPdfEditorCommandExecutor Create(IPdfEditor pdfEditor) => new PdfEditorCommandExecutor(pdfEditor);
}