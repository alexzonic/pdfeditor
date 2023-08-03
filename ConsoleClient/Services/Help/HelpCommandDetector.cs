using System;
using System.Linq;
using ConsoleClient.Exceptions;

namespace ConsoleClient.Services.Help
{
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
}