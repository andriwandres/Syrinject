using Cake.Frosting;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;

namespace Syrinject.Build.Tasks;

[TaskName(SyrinjectTaskNames.Test)]
[IsDependentOn(typeof(BuildTask))]
public sealed class TestTask : AsyncFrostingTask<BuildContext>
{
}
