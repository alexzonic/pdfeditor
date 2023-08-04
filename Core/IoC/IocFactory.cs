using JetBrains.Annotations;
using StructureMap;
using StructureMap.Pipeline;

namespace PdfEditor.Core.IoC;

public static class IocFactory
{
    [NotNull]
    private static readonly object Lock = new();

    [CanBeNull]
    private static Container Container;

    public static T GetInstance<T>() => GetContainer().GetInstance<T>();

    [NotNull]
    public static Container GetContainer()
    {
        if (Container == null)
            lock (Lock)
                if (Container == null)
                    Container ??= CreateContainer();

        return Container;
    }

    [NotNull]
    private static Container CreateContainer() =>
        new(r => r.Scan(s =>
        {
            s.AssembliesAndExecutablesFromApplicationBaseDirectory(a => a.GetName().Name.StartsWith("PdfEditor."));
            s.RegisterConcreteTypesAgainstTheFirstInterface()
             .OnAddedPluginTypes(c => c.LifecycleIs(Lifecycles.Singleton));
            s.LookForRegistries();
        }));

    public static void Dispose() => Container?.Dispose();
}