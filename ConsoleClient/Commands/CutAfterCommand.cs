using System.CommandLine;

namespace PdfEditor.ConsoleClient.Commands;

internal sealed class CutAfterCommand : CommandBase, ICommand
{
    public Command BuildCommand()
    {
        var command = new Command(CommandsList.CutAfter)
        {
            PathOption,
            new Option<int>(new[] {"-s", "--start"})
            {
                IsRequired = true,
                Arity = ArgumentArity.ExactlyOne,
            },
        };

        return command;
    }
}