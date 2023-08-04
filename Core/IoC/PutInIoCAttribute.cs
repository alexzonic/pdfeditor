using System;
using StructureMap.Pipeline;

namespace PdfEditor.Core.IoC;

[AttributeUsage(AttributeTargets.Class)]
public sealed class PutInIoCAttribute : Attribute
{
    public ILifecycle Lifecycle = Lifecycles.Singleton;
}