using System;
using System.Text;
using PdfEditor.ConsoleClient.Commands;
using Spectre.Console.Cli;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;
var app = new CommandApp();
app.Configure(
    config =>
    {
        config.SetApplicationName("pdfeditor");

        config.AddCommand<CutCommand>("cut")
            .WithDescription("Cut pages from pdf document by provided pages numbers ranges")
            .WithExample("cut", @"pth\to\document.pdf", "-r 1:5");
    }
);
var result = app.Run(args);
return result;