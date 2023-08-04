using JetBrains.Annotations;
using PdfEditor.Core.IoC;
using StructureMap;

namespace PdfEditor.Engine;

[UsedImplicitly]
internal sealed class EngineRegistry : Registry
{
    public EngineRegistry()
    {
        Scan(s =>
        {
            s.TheCallingAssembly();
            s.Convention<PutInIoCScanner<EngineRegistry>>();
        });
    }
}