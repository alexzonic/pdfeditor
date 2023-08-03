using System.Threading.Tasks;
using PdfEditor.Engine.Options;
using PdfSharp.Pdf;

namespace PdfEditor.Engine;

public interface IPdfEditor
{
    /// <summary>
    /// Обрезает документ с начала до указанной страницы (не включая ее)
    /// </summary>
    /// <param name="options">Страница, до которой обрезать документ</param>
    /// <returns>Completed Task</returns>
    Task<PdfDocument> CutUntilAsync(CutUntilOptions options);

    /// <summary>
    /// Обрезает документ с указанной страницы (включая ее) до конца
    /// </summary>
    /// <param name="options">Страница, с которой обрезать документ</param>
    /// <returns>Completed Task</returns>
    Task<PdfDocument> CutAfterAsync(CutAfterOptions options);

    /// <summary>
    /// Обрезает pagesCount страниц после startPage (включая ее)
    /// </summary>
    /// <param name="options">Параметры:<br/>
    /// StartPage - Страница, с которой обрезать документ<br/>
    /// PagesCount - Количество страниц для обрезания
    /// </param>
    /// <returns>Completed Task</returns>
    Task<PdfDocument> CutPartAsync(CutPartOptions options);

    /// <summary>
    /// Вырезает из документа заданные страницы
    /// </summary>
    /// <param name="options">Номера страниц, которые нужно удалить</param>
    /// <returns>Completed Task</returns>
    Task<PdfDocument> CutPagesAsync(CutPagesOptions options);

    /// <summary>
    /// Вырезает из документа все страницы, кроме указанных
    /// </summary>
    /// <param name="options">Номера страниц, которые нужно оставить</param>
    /// <returns>Completed Task</returns>
    Task<PdfDocument> CutPagesExceptAsync(CutPagesExceptOptions options);
}