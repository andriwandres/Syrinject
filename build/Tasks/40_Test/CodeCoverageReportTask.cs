using Cake.Common.Diagnostics;
using Cake.Common.IO;
using Cake.Common.Tools.ReportGenerator;
using Cake.Core.IO;
using Cake.Frosting;
using Cake.Incubator.GlobbingExtensions;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;

namespace Syrinject.Build.Tasks._40_Test;

[TaskName(SyrinjectTaskNames.CodeCoverageReport)]
[IsDependeeOf(typeof(TestTask))]
[IsDependentOn(typeof(TestDotNetTask))]
public sealed class CodeCoverageReportTask : AsyncFrostingTask<BuildContext>
{
    public override async Task RunAsync(BuildContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        TestContext testContext = context.TestContext;

        if (!context.DirectoryExists(testContext.CodeCoverageReportDirectoryPath))
        {
            context.CreateDirectory(testContext.CodeCoverageReportDirectoryPath);
        }

        ReportGeneratorSettings reportGeneratorSettings = new()
        {
            ReportTypes = { ReportGeneratorReportType.HtmlInline_AzurePipelines_Dark }
        };

        string coverageSummaryFilePath = testContext.CodeCoverageSummaryFilePath.FullPath;

        FilePathCollection files = context.GetFiles(coverageSummaryFilePath)!;

        if (files.Any())
        {
            context.ReportGenerator(
                testContext.CodeCoverageSummaryFilePath,
                testContext.CodeCoverageReportDirectoryPath,
                reportGeneratorSettings
            );
        }
        else
        {
            context.Warning("No cobertura.xml files found.");
        }

        await Task.CompletedTask;
    }
}
