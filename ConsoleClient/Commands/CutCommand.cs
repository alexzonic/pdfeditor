using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using PdfEditor.ConsoleClient.Utils;
using PdfEditor.Engine;
using PdfEditor.Engine.Options;
using Spectre.Console;
using Spectre.Console.Cli;

namespace PdfEditor.ConsoleClient.Commands;

[UsedImplicitly]
public sealed class CutCommand : Command<CutCommandSettings>
{
    public override int Execute(CommandContext context, CutCommandSettings settings)
    {
        var documentBuilder = new PdfDocumentBuilder();
        var document = documentBuilder.FromFile(settings.Path);

        var pageRanges = settings.Ranges.Select(r =>
                {
                    var split = r.Split(":");
                    var start = int.Parse(split[0]);
                    var end = int.TryParse(split[1], out var val) ? val : document.Pages.Count;
                    return new { start, end };
                }
            )
            .Select(x => Enumerable.Range(x.start, x.end - x.start).ToArray())
            .ToList();

        var pdfEditor = PdfEditorFactory.Create();
        var updatedDocument = pdfEditor.CutRange(new CutRangesOptions
            {
                Document = document,
                Ranges = pageRanges,
            }
        );

        var directoryPath = Path.GetDirectoryName(settings.Path);
        var updatedFileName = BuildUpdatedFileName(Path.GetFileName(settings.Path));

        updatedDocument.Save(@$"{directoryPath}\{updatedFileName}");
        return 0;
    }

    private string BuildUpdatedFileName(string originalName)
    {
        var fileName = string.Join("", originalName.Take(originalName.Length - ".pdf".Length));
        return $"{fileName}-{DateTime.Now.Ticks}.pdf";
    }
}

[UsedImplicitly]
public sealed class CutCommandSettings : CommandSettings
{
    [CommandArgument(0, "[PATH]")]
    public string Path { get; set; } = default!;

    [CommandOption("-r|--ranges <VALUES>")]
    public string[] Ranges { get; set; } = default!;

    public override ValidationResult Validate()
    {
        if (string.IsNullOrEmpty(Path) || !Path.EndsWith(".pdf"))
            return ValidationResult.Error("Invalid path");

        if (!File.Exists(Path))
            return ValidationResult.Error("File by this path doesnt exist");

        var invalidRanges = Ranges.Where(r => !Regexps.RangePattern.IsMatch(r)).ToArray();
        if (invalidRanges.Any())
            return ValidationResult.Error($"Invalid ranges: {string.Join(", ", invalidRanges)}");

        return ValidationResult.Success();
    }
}