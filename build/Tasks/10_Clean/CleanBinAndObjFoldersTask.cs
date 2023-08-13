using Cake.Common.IO;
using Cake.Core.IO;
using Cake.Frosting;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;

namespace Syrinject.Build.Tasks._10_Clean;

[TaskName(SyrinjectTaskNames.CleanBinAndObjFolders)]
[IsDependeeOf(typeof(CleanTask))]
public sealed class CleanBinAndObjFoldersTask : AsyncFrostingTask<BuildContext>
{
    public override async Task RunAsync(BuildContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        context.CleanDirectories("**/bin/", IsBuildFolder);
        context.CleanDirectories("**/obj/", IsBuildFolder);

        await Task.CompletedTask;
    }

    private static bool IsBuildFolder(IFileSystemInfo fileSystemInfo)
    {
        return !fileSystemInfo.Path.FullPath.Contains(SyrinjectPaths.BuildFolderName);
    }
}
