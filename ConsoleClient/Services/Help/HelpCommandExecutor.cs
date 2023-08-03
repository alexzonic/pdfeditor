using System;

namespace PdfEditor.ConsoleClient.Services.Help;

internal sealed class HelpCommandExecutor : IHelpCommandExecutor
{
    public void Execute()
    {
        Console.WriteLine("Welcome to Engine :)");
        Console.WriteLine("You can use next commands:");
        Console.WriteLine();

        Console.WriteLine($"{Commands.CutUntil}: cuts the document to the specified page");
        Console.WriteLine("\tthis command has arguments:");
        Console.WriteLine($"\t{Commands.Options.PageNumber}: page to which you want to cut the document");
        Console.WriteLine();

        //TODO про другие методы
    }
}