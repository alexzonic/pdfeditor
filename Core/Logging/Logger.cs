using System;

namespace PdfEditor.Core.Logging;

internal sealed class ConsoleLogger : ILogger
{
    public void Info(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] [Info] : {message}");
    }

    public void Warn(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] [Warn] : {message}");
    }

    public void Error(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] [Error] : {message}");
    }
}