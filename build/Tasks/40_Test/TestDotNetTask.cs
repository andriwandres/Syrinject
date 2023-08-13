using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Test;
using Cake.Core.IO;
using Cake.Frosting;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;

namespace Syrinject.Build.Tasks._40_Test;

[TaskName(SyrinjectTaskNames.TestDotNet)]
[IsDependeeOf(typeof(TestTask))]
public sealed class TestDotNetTask : AsyncFrostingTask<BuildContext>
{
    public override async Task RunAsync(BuildContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        foreach (FilePath testProjectPath in context.TestContext.TestProjectPaths)
        {
            DotNetTestSettings testSettings = new()
            {
                Configuration = SyrinjectBuildConstants.BuildConfiguration,
                Verbosity = DotNetVerbosity.Minimal,
                NoBuild = true,
            };

            context.DotNetTest(testProjectPath.FullPath, testSettings);
        }

        await Task.CompletedTask;
    }
}
