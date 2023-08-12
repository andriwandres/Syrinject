namespace Syrinject.IntegrationTests.TestServices;

internal interface ITestServiceWithOneConcreteDependency
{

}

internal sealed class TestServiceWithOneConcreteDependency : ITestServiceWithOneConcreteDependency
{
    public readonly TestServiceDependencyA DependencyA;

    public TestServiceWithOneConcreteDependency(TestServiceDependencyA dependencyA)
    {
        DependencyA = dependencyA;
    }
}
