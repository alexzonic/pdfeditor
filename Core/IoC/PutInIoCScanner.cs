using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;

namespace PdfEditor.Core.IoC;

public sealed class PutInIoCScanner<TLocator> : IRegistrationConvention
{
    public void ScanTypes(TypeSet types, Registry registry)
    {
        var nonPublicClasses = typeof(TLocator).Assembly.GetTypes().Where(IsInternalType);

        foreach (var nonPublicClass in nonPublicClasses)
        {
            foreach (var nonPublicClassInterface in nonPublicClass.GetInterfaces())
            {
                registry.For(nonPublicClassInterface).Use(nonPublicClass);
            }
        }
    }

    private static bool IsInternalType([NotNull] Type type)
        => type.GetCustomAttribute<PutInIoCAttribute>() != null;
}