using FluentAssertions;
using Syrinject.Core;
using Syrinject.Core.Abstractions;
using Syrinject.IntegrationTests.TestServices;

namespace Syrinject.IntegrationTests;

public sealed class ResolverTests
{
    private readonly ISyrinjectContainer _container;

    public ResolverTests()
    {
        _container = new SyrinjectContainer();
    }

    [Fact]
    public void Resolver_Should_Return_The_Concrete_Implementation_Of_Abstracted_Transient_Service()
    {
        _container.AddTransient<ITestServiceWithoutDependencies, TestServiceWithoutDependencies>();

        ISyrinjectResolver resolver = _container.Build();

        ITestServiceWithoutDependencies service = resolver.Resolve<ITestServiceWithoutDependencies>();

        service.Should().NotBeNull();
        service.Should().BeOfType<TestServiceWithoutDependencies>();
    }
}
