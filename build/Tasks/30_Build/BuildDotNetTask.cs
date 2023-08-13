using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Build;
using Cake.Frosting;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;

namespace Syrinject.Build.Tasks._30_Build;

[TaskName(SyrinjectTaskNames.BuildDotNet)]
[IsDependeeOf(typeof(BuildTask))]
public sealed class BuildDotNetTask : AsyncFrostingTask<BuildContext>
{
    public override async Task RunAsync(BuildContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        DotNetBuildSettings buildSettings = new()
        {
            Configuration = SyrinjectBuildConstants.BuildConfiguration,
            Verbosity = DotNetVerbosity.Minimal,
        };

        context.DotNetBuild(context.SolutionFilePath.FullPath, buildSettings);

        await Task.CompletedTask;
    }
}
