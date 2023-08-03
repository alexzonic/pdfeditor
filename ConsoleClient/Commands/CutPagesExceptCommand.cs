using System.CommandLine;

namespace PdfEditor.ConsoleClient.Commands;

internal sealed class CutPagesExceptCommand : CommandBase, ICommand
{
    public Command BuildCommand()
    {
        var command = new Command(CommandsList.CutPagesExcept)
        {
            PathOption,
            new Option<int[]>(new[] {"-ns", "--numbers"})
            {
                IsRequired = true,
            },
        };

        return command;
    }
}