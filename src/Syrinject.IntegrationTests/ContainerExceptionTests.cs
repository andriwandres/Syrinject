using FluentAssertions;
using Syrinject.Core;
using Syrinject.Core.Abstractions;
using Syrinject.IntegrationTests.TestServices;

namespace Syrinject.IntegrationTests;

public sealed class ContainerExceptionTests
{
    private readonly ISyrinjectContainer _container;

    public ContainerExceptionTests()
    {
        _container = new SyrinjectContainer();
    }

    [Fact]
    public void Container_Should_Throw_ArgumentNullException_When_Instance_Is_Null()
    {
        Action action = () => _container.AddSingleton((ITestServiceWithoutDependencies)null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Container_Should_Throw_ArgumentException_When_An_Instance_Singleton_Service_Is_Registered_Twice()
    {
        TestServiceWithoutDependencies service = new();

        _container.AddSingleton(service);

        Action action = () => _container.AddSingleton(service); ;

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Container_Should_Throw_ArgumentException_When_A_Concrete_Singleton_Service_Is_Registered_Twice()
    {
        _container.AddSingleton<TestServiceWithoutDependencies>();

        Action action = () => _container.AddSingleton<TestServiceWithoutDependencies>();

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Container_Should_Throw_ArgumentException_When_An_Abstracted_Singleton_Service_Is_Registered_Twice()
    {
        _container.AddSingleton<ITestServiceWithoutDependencies, TestServiceWithoutDependencies>();

        Action action = () => _container.AddSingleton<ITestServiceWithoutDependencies, TestServiceWithoutDependencies>();

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Container_Should_Throw_ArgumentException_When_A_Concrete_Transient_Service_Is_Registered_Twice()
    {
        _container.AddTransient<TestServiceWithoutDependencies>();

        Action action = () => _container.AddTransient<TestServiceWithoutDependencies>();

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Container_Should_Throw_ArgumentException_When_An_Abstracted_Transient_Service_Is_Registered_Twice()
    {
        _container.AddTransient<ITestServiceWithoutDependencies, TestServiceWithoutDependencies>();

        Action action = () => _container.AddTransient<ITestServiceWithoutDependencies, TestServiceWithoutDependencies>();

        action.Should().Throw<ArgumentException>();
    }
}
