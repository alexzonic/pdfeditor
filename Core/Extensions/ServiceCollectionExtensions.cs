using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using PdfEditor.Core.Attributes;

namespace PdfEditor.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAssembly(this IServiceCollection services) =>
        services.AddAssembly(Assembly.GetCallingAssembly());

    public static IServiceCollection AddAssembly(this IServiceCollection services, Assembly assembly) =>
        services.AddTypes(assembly.GetTypes());

    internal static IServiceCollection AddTypes(this IServiceCollection services, IEnumerable<Type> types)
    {
        foreach (var implementationType in types)
        {
            var configs = implementationType.GetCustomAttribute<AddServiceAttribute>();
            if (configs is null)
                continue;

            if (configs.Directly)
            {
                services.Add(new(implementationType, implementationType, configs.Lifetime));
                continue;
            }

            var serviceTypes = implementationType.GetInterfaces();
            if (serviceTypes.Length is 0)
            {
                ThrowIfNonOptional(implementationType, configs.Optional);
                continue;
            }

            foreach (var serviceType in serviceTypes)
                services.Add(new(serviceType, implementationType, configs.Lifetime));
        }

        return services;
    }

    [ContractAnnotation("optional: false => halt")]
    private static void ThrowIfNonOptional(Type implementationType, bool optional)
    {
        if (optional)
            return;

        var name = implementationType.FullName ?? implementationType.Name;
        throw new InvalidOperationException($"No type was specified to register {name} in container");
    }
}