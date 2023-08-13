using Cake.Core;
using Cake.Core.IO;
using Cake.Incubator.GlobbingExtensions;
using Syrinject.Build.Constants;

namespace Syrinject.Build.Context;

public sealed class TestContext
{
    public IEnumerable<FilePath> TestProjectPaths { get; }

    public TestContext(ICakeContext context, BuildContext buildContext)
    {
        TestProjectPaths = context.GetFiles(SyrinjectBuildConstants.TestProjectSearchPatterns);
    }
}
