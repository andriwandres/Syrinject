using Cake.Frosting;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;
using Syrinject.Build.Extensions;
using Syrinject.Build.Tasks;

new CakeHost()
    .UseContext<BuildContext>()
    .InstallSyrinjectTools()
    .UseWorkingDirectory("..")
    .Run(args);

[TaskName(SyrinjectTaskNames.Default)]
[IsDependentOn(typeof(PullRequestBuildTask))]
public sealed class DefaultTask : AsyncFrostingTask<BuildContext>
{
}

[TaskName(SyrinjectTaskNames.PullRequestBuild)]
[IsDependentOn(typeof(TestTask))]
public sealed class PullRequestBuildTask : AsyncFrostingTask<BuildContext>
{
}