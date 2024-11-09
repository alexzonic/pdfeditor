namespace PdfEditor.Engine;

public static class PdfEditorFactory
{
    /// <summary>
    /// Создает экземпляр IPdfEditor
    /// </summary>
    /// <returns>Instance of IPdfEditor</returns>
    public static IPdfEditor Create() => new PdfEditor();
}