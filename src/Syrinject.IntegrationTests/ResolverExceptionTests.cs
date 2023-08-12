using FluentAssertions;
using Syrinject.Core;
using Syrinject.Core.Abstractions;
using Syrinject.IntegrationTests.TestServices;

namespace Syrinject.IntegrationTests;

public sealed class ResolverExceptionTests
{
    private readonly ISyrinjectContainer _container;

    public ResolverExceptionTests()
    {
        _container = new SyrinjectContainer();
    }

    [Fact]
    public void Resolver_Should_Throw_ArgumentException_When_Requested_Service_Cannot_Be_Resolved()
    {
        ISyrinjectResolver resolver = _container.Build();

        Action action = () => resolver.Resolve<ITestServiceWithoutDependencies>();

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Resolver_Should_Throw_ArgumentException_When_Requested_Service_Has_A_Dependency_Which_Cannot_Be_Resolved()
    {
        _container.AddTransient<ITestServiceWithOneAbstractedDependency, TestServiceWithOneAbstractedDependency>();

        ISyrinjectResolver resolver = _container.Build();

        Action action = () => resolver.Resolve<ITestServiceWithOneAbstractedDependency>();

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Resolver_Should_Throw_InvalidOperationException_When_Requested_Service_Has_Two_Constructors()
    {
        _container.AddTransient<ITestServiceWithTwoConstructors, TestServiceWithTwoConstructors>();

        ISyrinjectResolver resolver = _container.Build();

        Action action = () => resolver.Resolve<ITestServiceWithTwoConstructors>();

        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Resolver_Should_Throw_ArgumentException_When_Concrete_ImplementationType_Is_Interface()
    {
        _container.AddTransient<ITestServiceWithoutDependencies>();

        ISyrinjectResolver resolver = _container.Build();

        Action action = () => resolver.Resolve<ITestServiceWithoutDependencies>();

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Resolver_Should_Throw_ArgumentException_When_Concrete_ImplementationType_Is_Abstract_Class()
    {
        _container.AddTransient<AbstractTestService>();

        ISyrinjectResolver resolver = _container.Build();

        Action action = () => resolver.Resolve<AbstractTestService>();

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Resolver_Should_Throw_ArgumentException_When_Abstracted_ImplementationType_Is_Interface()
    {
        _container.AddTransient<ITestServiceWithInterface, ITestServiceWithWithNestedInterface>();

        ISyrinjectResolver resolver = _container.Build();

        Action action = () => resolver.Resolve<ITestServiceWithoutDependencies>();

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Resolver_Should_Throw_ArgumentException_When_Abstracted_ImplementationType_Is_Abstract_Class()
    {
        _container.AddTransient<AbstractTestService, TestServiceWithNestedAbstractClass>();

        ISyrinjectResolver resolver = _container.Build();

        Action action = () => resolver.Resolve<AbstractTestService>();

        action.Should().Throw<ArgumentException>();
    }
}
