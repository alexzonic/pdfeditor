namespace PdfEditor.Engine;

public static class PdfEditorFactory
{
    /// <summary>
    /// Создает экземпляр IPdfEditor
    /// </summary>
    /// <param name="sourceFilePath">Путь до оригинального pdf файла</param>
    /// <param name="editedFileName">Имя обновленного pdf файла. По умолчанию 'updated_имя-оригинала'</param>
    /// <returns>Instance of IPdfEditor</returns>
    public static IPdfEditor Create() => new PdfEditor();
}