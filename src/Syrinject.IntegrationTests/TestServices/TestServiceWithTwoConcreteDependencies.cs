namespace Syrinject.IntegrationTests.TestServices;

internal interface ITestServiceWithTwoConcreteDependencies
{

}

internal sealed class TestServiceWithTwoConcreteDependencies : ITestServiceWithTwoConcreteDependencies
{
    public readonly TestServiceDependencyA DependencyA;
    public readonly TestServiceDependencyB DependencyB;

    public TestServiceWithTwoConcreteDependencies(
        TestServiceDependencyA dependencyA, 
        TestServiceDependencyB dependencyB)
    {
        DependencyA = dependencyA;
        DependencyB = dependencyB;
    }
}
