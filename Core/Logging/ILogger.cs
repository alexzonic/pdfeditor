using JetBrains.Annotations;

namespace PdfEditor.Core.Logging;

public interface ILogger
{
    void Info([NotNull] string message);
    void Warn([NotNull] string message);
    void Error([NotNull] string message);
}