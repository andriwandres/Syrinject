namespace Syrinject.Core.Abstractions;

public interface ISyrinjectResolver
{
    object Resolve(Type type);
    TService Resolve<TService>() where TService : class;
}
