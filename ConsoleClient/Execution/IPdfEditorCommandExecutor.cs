using System.Threading.Tasks;

namespace ConsoleClient.Execution
{
    public interface IPdfEditorCommandExecutor
    {
        Task Execute(string command, object options);
    }
}