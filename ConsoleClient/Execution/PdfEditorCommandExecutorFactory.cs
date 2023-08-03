using PdfEditor;

namespace ConsoleClient.Execution
{
    internal static class PdfEditorCommandExecutorFactory
    {
        public static IPdfEditorCommandExecutor Create(IPdfEditor pdfEditor) => new PdfEditorCommandExecutor(pdfEditor);
    }
}