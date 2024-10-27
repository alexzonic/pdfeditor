using System.Collections.Generic;

namespace PdfEditor.Engine.Options;

public sealed record CutRangesOptions : OptionsBase
{
    public List<int[]> Ranges { get; init; }
}
