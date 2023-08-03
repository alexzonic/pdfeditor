using System;

namespace PdfEditor.Core.Logging;

internal sealed class ConsoleLogger : ILogger
{
    public void Info(string message)
    {
        Console.WriteLine(@$"[Info]\t {message}");
    }

    public void Warn(string message)
    {
        Console.WriteLine(@$"[Warn]\t {message}");
    }

    public void Error(string message)
    {
        Console.WriteLine(@$"[Error]\t {message}");
    }
}