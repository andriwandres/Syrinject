using FluentAssertions;
using Syrinject.Core;
using Syrinject.Core.Abstractions;
using Syrinject.IntegrationTests.TestServices;

namespace Syrinject.IntegrationTests;

public sealed class LifetimeTests
{
    private readonly ISyrinjectContainer _container;

    public LifetimeTests()
    {
        _container = new SyrinjectContainer();
    }

    [Fact]
    public void Resolver_Should_Return_The_Same_Instance_For_Concrete_Singleton_Services()
    {
        _container.AddSingleton<TestServiceWithoutDependencies>();

        ISyrinjectResolver resolver = _container.Build();

        TestServiceWithoutDependencies serviceA = resolver.Resolve<TestServiceWithoutDependencies>();
        TestServiceWithoutDependencies serviceB = resolver.Resolve<TestServiceWithoutDependencies>();

        serviceA.Should().NotBeNull();
        serviceB.Should().NotBeNull();

        serviceA.Should().Be(serviceB);
    }

    [Fact]
    public void Resolver_Should_Return_The_Same_Instance_For_Abstracted_Singleton_Services()
    {
        _container.AddSingleton<ITestServiceWithoutDependencies, TestServiceWithoutDependencies>();

        ISyrinjectResolver resolver = _container.Build();

        ITestServiceWithoutDependencies serviceA = resolver.Resolve<ITestServiceWithoutDependencies>();
        ITestServiceWithoutDependencies serviceB = resolver.Resolve<ITestServiceWithoutDependencies>();

        serviceA.Should().NotBeNull();
        serviceB.Should().NotBeNull();

        serviceA.Should().Be(serviceB);
    }

    [Fact]
    public void Resolver_Should_Return_The_Same_Instance_For_Instance_Singleton_Services()
    {
        _container.AddSingleton(new TestServiceWithoutDependencies());

        ISyrinjectResolver resolver = _container.Build();

        TestServiceWithoutDependencies serviceA = resolver.Resolve<TestServiceWithoutDependencies>();
        TestServiceWithoutDependencies serviceB = resolver.Resolve<TestServiceWithoutDependencies>();

        serviceA.Should().NotBeNull();
        serviceB.Should().NotBeNull();

        serviceA.Should().Be(serviceB);
    }

    [Fact]
    public void Resolver_Should_Return_Different_Instances_For_Concrete_Transient_Services()
    {
        _container.AddTransient<TestServiceWithoutDependencies>();

        ISyrinjectResolver resolver = _container.Build();

        TestServiceWithoutDependencies serviceA = resolver.Resolve<TestServiceWithoutDependencies>();
        TestServiceWithoutDependencies serviceB = resolver.Resolve<TestServiceWithoutDependencies>();

        serviceA.Should().NotBeNull();
        serviceB.Should().NotBeNull();

        serviceA.Should().NotBe(serviceB);
    }

    [Fact]
    public void Resolver_Should_Return_Different_Instances_For_Abstracted_Transient_Services()
    {
        _container.AddTransient<ITestServiceWithoutDependencies, TestServiceWithoutDependencies>();

        ISyrinjectResolver resolver = _container.Build();

        ITestServiceWithoutDependencies serviceA = resolver.Resolve<ITestServiceWithoutDependencies>();
        ITestServiceWithoutDependencies serviceB = resolver.Resolve<ITestServiceWithoutDependencies>();

        serviceA.Should().NotBeNull();
        serviceB.Should().NotBeNull();

        serviceA.Should().NotBe(serviceB);
    }

    [Fact]
    public void Resolver_Should_Return_The_Same_Instance_For_Transient_Service_When_The_Parent_Is_A_Singleton_Service()
    {
        _container
            .AddTransient<TestServiceDependencyA>()
            .AddSingleton<TestServiceWithOneConcreteDependency>();

        ISyrinjectResolver resolver = _container.Build();

        TestServiceWithOneConcreteDependency serviceA = resolver.Resolve<TestServiceWithOneConcreteDependency>();
        TestServiceWithOneConcreteDependency serviceB = resolver.Resolve<TestServiceWithOneConcreteDependency>();

        serviceA.Should().NotBeNull();
        serviceB.Should().NotBeNull();

        serviceA.DependencyA.Should().NotBeNull();
        serviceB.DependencyA.Should().NotBeNull();

        serviceA.DependencyA.Should().Be(serviceB.DependencyA);
    }
}
