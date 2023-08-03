using System;

namespace ConsoleClient.Exceptions
{
    internal sealed class HelpCommandDetectException : Exception
    {
        public HelpCommandDetectException() : base("Incorrect --help command")
        {
        }
    }
}