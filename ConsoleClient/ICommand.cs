using System.CommandLine;

namespace PdfEditor.ConsoleClient;

public interface ICommand
{
    Command BuildCommand();
}