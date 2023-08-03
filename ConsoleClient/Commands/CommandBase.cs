using System.CommandLine;

namespace PdfEditor.ConsoleClient.Commands;

internal abstract class CommandBase
{
    protected Option<string> PathOption => new(new[] {"-p", "--path"})
    {
        IsRequired = true,
        Arity = ArgumentArity.ExactlyOne,
    };
}