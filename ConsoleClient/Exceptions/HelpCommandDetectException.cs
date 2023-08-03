using System;

namespace PdfEditor.ConsoleClient.Exceptions;

internal sealed class HelpCommandDetectException : Exception
{
    public HelpCommandDetectException() : base("Incorrect --help command")
    {
    }
}