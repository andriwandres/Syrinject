using System.Runtime.InteropServices.JavaScript;
using Cake.Common.IO;
using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Test;
using Cake.Core;
using Cake.Core.IO;
using Cake.Frosting;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;
using System.Text;
using Cake.Common.Diagnostics;

namespace Syrinject.Build.Tasks._40_Test;

[TaskName(SyrinjectTaskNames.TestDotNet)]
[IsDependeeOf(typeof(TestTask))]
public sealed class TestDotNetTask : AsyncFrostingTask<BuildContext>
{
    public override async Task RunAsync(BuildContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        TestContext testContext = context.TestContext;

        if (!context.DirectoryExists(testContext.CoverletDirectoryPath))
        {
            context.CreateDirectory(testContext.CoverletDirectoryPath);
        }

        foreach (FilePath testProjectPath in testContext.TestProjectPaths)
        {
            string artifactFileName = GetArtifactFileName(testProjectPath);
            string customArguments = BuildCustomArguments(artifactFileName, testContext);

            context.Information("ArgumentCustomization: " + customArguments);

            DotNetTestSettings testSettings = new()
            {
                Configuration = SyrinjectBuildConstants.BuildConfiguration,
                Verbosity = DotNetVerbosity.Minimal,
                NoBuild = true,
                ResultsDirectory = testContext.TestResultsDirectoryPath,
                ArgumentCustomization = args => args.Append(customArguments),
            };

            context.DotNetTest(testProjectPath.FullPath, testSettings);
        }

        await Task.CompletedTask;
    }

    private static string BuildCustomArguments(string artifactFileName, TestContext testContext)
    {
        return new StringBuilder()
            .Append($@"--logger ""trx;LogFileName={artifactFileName}"" ")
            .Append($@"/p:CollectCoverage=true ")
            .Append($@"/p:CoverletOutput=""{testContext.CoverletDirectoryPath.FullPath}/"" ")
            .Append($@"/p:MergeWith=""{testContext.CoverletDirectoryPath.FullPath}/coverage.json"" ")
            .Append($@"/p:CoverletOutputFormat=""cobertura%2cjson"" ")
            .Append($@"-m:1")
            .ToString();
    }

    private static string GetArtifactFileName(FilePath testProjectPath)
    {
        string testProjectFileName = testProjectPath.GetFilenameWithoutExtension().FullPath.Replace(".", "-");
        string timestamp = $"{DateTime.UtcNow:yyyyMMddHHmmss}";

        return $"{testProjectFileName}-Results-{timestamp}.trx";
    }
}
