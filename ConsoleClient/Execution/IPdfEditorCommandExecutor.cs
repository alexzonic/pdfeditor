using System.Threading.Tasks;

namespace PdfEditor.ConsoleClient.Execution;

public interface IPdfEditorCommandExecutor
{
    Task Execute(string command, object options);
}