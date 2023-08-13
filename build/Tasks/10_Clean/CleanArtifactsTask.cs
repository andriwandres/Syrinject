using Cake.Common.IO;
using Cake.Core.IO;
using Cake.Frosting;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;

namespace Syrinject.Build.Tasks._10_Clean;

[TaskName(SyrinjectTaskNames.CleanArtifacts)]
[IsDependeeOf(typeof(CleanTask))]
public sealed class CleanArtifactsTask : AsyncFrostingTask<BuildContext>
{
    public override async Task RunAsync(BuildContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        DirectoryPath artifactsPath = context.ArtifactsDirectoryPath;

        if (!context.DirectoryExists(artifactsPath))
        {
            context.CreateDirectory(artifactsPath);
        }

        context.CleanDirectory(artifactsPath);

        await Task.CompletedTask;
    }
}
