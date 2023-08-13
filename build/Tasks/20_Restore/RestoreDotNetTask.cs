using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Restore;
using Cake.Frosting;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;

namespace Syrinject.Build.Tasks._20_Restore;

[TaskName(SyrinjectTaskNames.RestoreDotNet)]
[IsDependeeOf(typeof(RestoreTask))]
public sealed class RestoreDotNetTask : AsyncFrostingTask<BuildContext>
{
    public override async Task RunAsync(BuildContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        DotNetRestoreSettings restoreSettings = new()
        {
            Verbosity = DotNetVerbosity.Minimal,
            Sources = { SyrinjectPaths.NuGetPackageSource }
        };

        context.DotNetRestore(context.SolutionFilePath.FullPath, restoreSettings);

        await Task.CompletedTask;
    }
}
