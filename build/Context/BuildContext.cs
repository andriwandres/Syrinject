using Cake.Common.IO;
using Cake.Core;
using Cake.Core.IO;
using Cake.Frosting;
using Syrinject.Build.Constants;

namespace Syrinject.Build.Context;

public sealed class BuildContext : FrostingContext
{
    public FilePath SolutionFilePath { get; }
    public DirectoryPath ArtifactsDirectoryPath { get; }
    public TestContext TestContext { get; }

    public BuildContext(ICakeContext context) : base(context)
    {
        ArtifactsDirectoryPath = context.MakeAbsolute(new DirectoryPath(SyrinjectPaths.ArtifactsDirectoryPath));
        SolutionFilePath = context.Environment.WorkingDirectory.CombineWithFilePath(SyrinjectPaths.SolutionFilePath);

        TestContext = new TestContext(context, this);
    }
}
