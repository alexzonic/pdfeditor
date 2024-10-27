using System.Text.RegularExpressions;

namespace PdfEditor.ConsoleClient.Utils;

public static class Regexps
{
    public static readonly Regex RangePattern = new(@"^\d+\:\d+$", RegexOptions.Compiled);
}