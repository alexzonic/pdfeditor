using JetBrains.Annotations;
using PdfEditor.Core.IoC;
using StructureMap;

namespace PdfEditor.Core;

[UsedImplicitly]
public sealed class CoreRegistry : Registry
{
    public CoreRegistry()
    {
        Scan(s =>
        {
            s.TheCallingAssembly();
            s.Convention<PutInIoCScanner<CoreRegistry>>();
        });
    }
}