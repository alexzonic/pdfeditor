using System.CommandLine;

namespace PdfEditor.ConsoleClient.Commands;

internal sealed class CutPagesCommand : CommandBase, ICommand
{
    public Command BuildCommand()
    {
        var command = new Command(CommandsList.CutPages)
        {
            PathOption,
            new Option<int>(new[] {"-ns", "--numbers"})
            {
                IsRequired = true,
                Arity = ArgumentArity.ExactlyOne,
            },
        };

        return command;
    }
}