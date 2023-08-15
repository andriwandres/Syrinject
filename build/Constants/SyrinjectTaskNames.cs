namespace Syrinject.Build.Constants;

internal static class SyrinjectTaskNames
{
    public const string Default = "Default";
    public const string PullRequestBuild = "PullRequestBuild";
    public const string ContinuousIntegrationBuild = "ContinuousIntegrationBuild";

    public const string Clean = "Clean";
    public const string CleanArtifacts = "CleanArtifacts";
    public const string CleanBinAndObjFolders = "CleanBinAndObjFolders";

    public const string Restore = "Restore";
    public const string RestoreDotNet = "RestoreDotNet";

    public const string Build = "Build";
    public const string BuildDotNet = "BuildDotNet";

    public const string Test = "Test";
    public const string TestDotNet = "TestDotNet";
    public const string CodeCoverageReport = "CodeCoverageReport";

}
