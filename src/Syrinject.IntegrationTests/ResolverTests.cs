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

    [Fact]
    public void Resolver_Should_Return_The_Same_Type_Given_A_Type_Instance_As_Opposed_To_A_Generic_Type()
    {
        _container.AddTransient<ITestServiceWithoutDependencies, TestServiceWithoutDependencies>();

        ISyrinjectResolver resolver = _container.Build();

        object serviceResolvedWithTypeInstance = resolver.Resolve(typeof(ITestServiceWithoutDependencies));

        serviceResolvedWithTypeInstance.Should().NotBeNull();
        serviceResolvedWithTypeInstance.Should().BeOfType<TestServiceWithoutDependencies>();
    }
}
