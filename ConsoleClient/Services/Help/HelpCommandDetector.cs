using System.Linq;
using PdfEditor.ConsoleClient.Exceptions;

namespace PdfEditor.ConsoleClient.Services.Help;

internal sealed class HelpCommandDetector : IHelpCommandDetector
{
    public bool Detect(string[] args)
    {
        var contains = args.Contains(Commands.Help);
        if (contains && args.Length != 1)
            throw new HelpCommandDetectException();
        return true;
    }
}