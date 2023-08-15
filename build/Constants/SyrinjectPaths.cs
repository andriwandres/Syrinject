namespace Syrinject.Build.Constants;

internal static class SyrinjectPaths
{
    public const string BuildFolderName = "build";
    public const string ArtifactsDirectoryPath = $"{BuildFolderName}/artifacts";

    private const string SourceFolderName = "src";
    public const string SolutionFilePath = $"{SourceFolderName}/Syrinject.sln";

    public const string TestResultsDirectoryName = "testResults";
    public const string CodeCoverageReportDirectoryName = "codeCoverage";
    public const string CoverletDirectoryName = "coverlet";
    public const string CoverageSummaryFileName = "coverage.cobertura.xml";

    public const string NuGetPackageSource = "https://api.nuget.org/v3/index.json";
}
