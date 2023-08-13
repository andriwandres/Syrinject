using Cake.Frosting;
using Syrinject.Build.Constants;
using Syrinject.Build.Context;

namespace Syrinject.Build.Tasks;

[TaskName(SyrinjectTaskNames.Clean)]
public sealed class CleanTask : AsyncFrostingTask<BuildContext>
{
}
