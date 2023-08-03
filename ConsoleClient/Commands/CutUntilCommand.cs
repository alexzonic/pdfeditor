using System.CommandLine;

namespace PdfEditor.ConsoleClient.Commands;

internal sealed class CutUntilCommand : CommandBase, ICommand
{
    public Command BuildCommand()
    {
        var command = new Command(CommandsList.CutUntil)
        {
            PathOption,
            new Option<int>(new[] {"-n", "--number"})
            {
                IsRequired = true,
                Arity = ArgumentArity.ExactlyOne,
            },
        };

        return command;
    }
}