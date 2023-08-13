using Cake.Frosting;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;

namespace Syrinject.Build.Tasks;

[TaskName(SyrinjectTaskNames.Build)]
[IsDependentOn(typeof(RestoreTask))]
public sealed class BuildTask : AsyncFrostingTask<BuildContext>
{
}
