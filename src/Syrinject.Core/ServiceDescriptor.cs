namespace Syrinject.Core;

internal sealed record ServiceDescriptor(
    Type ServiceType, 
    Type ImplementationType, 
    ServiceLifetime Lifetime)
{
    public object? Implementation { get; set; }
}
