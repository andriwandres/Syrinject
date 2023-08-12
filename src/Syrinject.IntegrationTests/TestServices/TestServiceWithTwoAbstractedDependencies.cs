namespace Syrinject.IntegrationTests.TestServices;

internal interface ITestServiceWithTwoAbstractedDependencies
{

}

internal sealed class TestServiceWithTwoAbstractedDependencies : ITestServiceWithTwoAbstractedDependencies
{
    public readonly ITestServiceDependencyA DependencyA;
    public readonly ITestServiceDependencyB DependencyB;

    public TestServiceWithTwoAbstractedDependencies(
        ITestServiceDependencyA dependencyA, 
        ITestServiceDependencyB dependencyB)
    {
        DependencyA = dependencyA;
        DependencyB = dependencyB;
    }
}
