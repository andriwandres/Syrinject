using Cake.Frosting;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;

namespace Syrinject.Build.Tasks;

[TaskName(SyrinjectTaskNames.Restore)]
[IsDependentOn(typeof(CleanTask))]
public sealed class RestoreTask : AsyncFrostingTask<BuildContext>
{

}
