using System.CommandLine;

namespace PdfEditor.ConsoleClient.Commands;

internal sealed class CutPartCommand : CommandBase, ICommand
{
    public Command BuildCommand()
    {
        var command = new Command(CommandsList.CutPart)
        {
            PathOption,
            new Option<int>(new[] {"-s", "--start"})
            {
                IsRequired = true,
                Arity = ArgumentArity.ExactlyOne,
            },
            new Option<int>(new[] {"-c", "--count"})
            {
                IsRequired = true,
                Arity = ArgumentArity.ExactlyOne,
            },
        };

        return command;
    }
}