using Syrinject.Core.Abstractions;
using System.Reflection;

namespace Syrinject.Core;

internal sealed class SyrinjectResolver : ISyrinjectResolver
{
    private readonly IEnumerable<ServiceDescriptor> _serviceDescriptors;

    public SyrinjectResolver(IEnumerable<ServiceDescriptor> serviceDescriptors)
    {
        _serviceDescriptors = serviceDescriptors;
    }
    
    public object Resolve(Type type)
    {
        ServiceDescriptor? descriptor = _serviceDescriptors
            .SingleOrDefault(d => d.ServiceType == type);

        if (descriptor is null)
        {
            throw new ArgumentException("cannot resolve service");
        }

        if (descriptor.Implementation is not null)
        {
            return descriptor.Implementation;
        }

        if (descriptor.ImplementationType.IsAbstract || descriptor.ImplementationType.IsInterface)
        {
            throw new ArgumentException("cannot instantiate type");
        }

        ConstructorInfo[] constructors = descriptor.ImplementationType.GetConstructors();
        
        if (constructors.Length is not 1)
        {
            throw new InvalidOperationException("too many arguments");
        }

        object[] arguments = constructors
            .Single()
            .GetParameters()
            .Select(parameter => Resolve(parameter.ParameterType))
            .ToArray();

        object? implementation = Activator.CreateInstance(descriptor.ImplementationType, arguments);

        if (implementation is null)
        {
            throw new InvalidOperationException("cannot resolve service");
        }

        if (descriptor.Lifetime == ServiceLifetime.Singleton)
        {
            descriptor.Implementation = implementation;
        }

        return implementation;
    }

    public TService Resolve<TService>() where TService : class
    {
        return (TService)Resolve(typeof(TService));
    }
}
