using Syrinject.Core.Abstractions;

namespace Syrinject.Core;

internal sealed class SyrinjectContainer : ISyrinjectContainer
{
    private readonly ISet<ServiceDescriptor> _services;

    public SyrinjectContainer()
    {
        _services = new HashSet<ServiceDescriptor>();
    }

    public ISyrinjectContainer AddSingleton<TService>() where TService : class
    {
        Type type = typeof(TService);

        ServiceDescriptor descriptor = new(
            ServiceType: type, 
            ImplementationType: type, 
            Lifetime: ServiceLifetime.Singleton
        );

        if (!_services.Add(descriptor))
        {
            throw new ArgumentException("cannot register service twice");
        };

        return this;
    }

    public ISyrinjectContainer AddSingleton<TService, TImplementation>() 
        where TService : class where TImplementation : TService
    {
        ServiceDescriptor descriptor = new(
            ServiceType: typeof(TService), 
            ImplementationType: typeof(TImplementation), 
            Lifetime: ServiceLifetime.Singleton
        );

        if (!_services.Add(descriptor))
        {
            throw new ArgumentException("cannot register service twice");
        };

        return this;
    }

    public ISyrinjectContainer AddSingleton<TService>(TService instance) 
        where TService : class
    {
        ArgumentNullException.ThrowIfNull(instance);

        Type type = typeof(TService);

        ServiceDescriptor descriptor = new(
            ServiceType: type, 
            ImplementationType: type, 
            Lifetime: ServiceLifetime.Singleton)
        {
            Implementation = instance,
        };

        if (!_services.Add(descriptor))
        {
            throw new ArgumentException("cannot register service twice");
        };

        return this;
    }

    public ISyrinjectContainer AddTransient<TService>() where TService : class
    {
        Type type = typeof(TService);

        ServiceDescriptor descriptor = new(
            ServiceType: type,
            ImplementationType: type,
            Lifetime: ServiceLifetime.Transient
        );

        if (!_services.Add(descriptor))
        {
            throw new ArgumentException("cannot register service twice");
        };

        return this;
    }

    public ISyrinjectContainer AddTransient<TService, TImplementation>() where TService : class where TImplementation : TService
    {
        ServiceDescriptor descriptor = new(
            ServiceType: typeof(TService),
            ImplementationType: typeof(TImplementation),
            Lifetime: ServiceLifetime.Transient
        );

        if (!_services.Add(descriptor))
        {
            throw new ArgumentException("cannot register service twice");
        };

        return this;
    }

    public ISyrinjectResolver Build()
    {
        return new SyrinjectResolver(_services);
    }
}
