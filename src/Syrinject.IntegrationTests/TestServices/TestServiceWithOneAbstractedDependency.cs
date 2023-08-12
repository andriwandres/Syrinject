namespace Syrinject.IntegrationTests.TestServices;

internal interface ITestServiceWithOneAbstractedDependency
{

}

internal sealed class TestServiceWithOneAbstractedDependency : ITestServiceWithOneAbstractedDependency
{
    public readonly ITestServiceDependencyA DependencyA;

    public TestServiceWithOneAbstractedDependency(ITestServiceDependencyA dependencyA)
    {
        DependencyA = dependencyA;
    }
}
