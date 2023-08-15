namespace Syrinject.Build.Constants;

internal static class SyrinjectBuildConstants
{
    public const string BuildConfiguration = "Release";

    public static readonly string[] TestProjectSearchPatterns = 
    {
        "src/**/*.UnitTests.csproj",
        "src/**/*.IntegrationTests.csproj",
    };
}
