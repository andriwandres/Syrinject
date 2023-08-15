using Cake.Core;
using Cake.Core.IO;
using Cake.Incubator.GlobbingExtensions;
using Syrinject.Build.Constants;

namespace Syrinject.Build.Context;

public sealed class TestContext
{
    public IEnumerable<FilePath> TestProjectPaths { get; }
    public DirectoryPath TestResultsDirectoryPath { get; }
    public ICollection<FilePath> TestResultFiles { get; }
    public DirectoryPath CodeCoverageReportDirectoryPath { get; }
    public DirectoryPath CoverletDirectoryPath { get; }
    public FilePath CodeCoverageSummaryFilePath { get; }

    public TestContext(ICakeContext context, BuildContext buildContext)
    {
        TestProjectPaths = context.GetFiles(SyrinjectBuildConstants.TestProjectSearchPatterns);
        TestResultsDirectoryPath = buildContext.ArtifactsDirectoryPath.Combine(new DirectoryPath(SyrinjectPaths.TestResultsDirectoryName));
        TestResultFiles = new List<FilePath>();

        CoverletDirectoryPath = TestResultsDirectoryPath.Combine(SyrinjectPaths.CoverletDirectoryName);
        CodeCoverageSummaryFilePath = CoverletDirectoryPath.CombineWithFilePath(SyrinjectPaths.CoverageSummaryFileName);

        CodeCoverageReportDirectoryPath = TestResultsDirectoryPath.Combine(SyrinjectPaths.CodeCoverageReportDirectoryName);
    }
}
