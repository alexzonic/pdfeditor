using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace PdfEditor.Core.Attributes;

[AttributeUsage(AttributeTargets.Class)]
[MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
public sealed class AddServiceAttribute : Attribute
{
    public AddServiceAttribute(ServiceLifetime lifetime = ServiceLifetime.Singleton) =>
        Lifetime = lifetime;

    /// <summary>
    /// Срок жизни сервиса <see cref="ServiceLifetime" />
    /// </summary>
    public ServiceLifetime Lifetime { get; }

    /// <summary>
    /// Возвращает или задает логическое значение, указывающее на необходимость
    /// зарегистрировать сервис под собственным типом
    /// </summary>
    /// <returns>
    /// <c>true</c> если сервис регистрируется под собственным типом; иначе <c>false</c>.
    /// По умолчанию <c>false</c>
    /// </returns>
    public bool Directly { get; set; }

    /// <summary>
    /// Возвращает или задает логическое значение, указывающее на обязательность
    /// регистрации сервиса
    /// </summary>
    /// <returns>
    /// <c>true</c> если регистрация сервиса не является необходимой; иначе <c>false</c>.
    /// По умолчанию <c>false</c>
    /// </returns>
    public bool Optional { get; set; }
}