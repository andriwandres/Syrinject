namespace Syrinject.Core.Abstractions;

public interface ISyrinjectContainer
{
    ISyrinjectContainer AddSingleton<TService>()
        where TService : class;

    ISyrinjectContainer AddSingleton<TService, TImplementation>()
        where TService : class
        where TImplementation : TService;

    ISyrinjectContainer AddSingleton<TService>(TService instance)
        where TService : class;

    ISyrinjectContainer AddTransient<TService>()
        where TService : class;

    ISyrinjectContainer AddTransient<TService, TImplementation>()
        where TService : class
        where TImplementation : TService;

    ISyrinjectResolver Build();
}
