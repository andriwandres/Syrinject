namespace Syrinject.IntegrationTests.TestServices;

internal interface ITestServiceWithTwoConstructors
{

}

internal sealed class TestServiceWithTwoConstructors : ITestServiceWithTwoConstructors
{
    public readonly ITestServiceDependencyA DependencyA;

    public TestServiceWithTwoConstructors(ITestServiceDependencyA dependencyA)
    {
        DependencyA = dependencyA;
    }

    public TestServiceWithTwoConstructors()
    {
        DependencyA = null!;
    }
}
