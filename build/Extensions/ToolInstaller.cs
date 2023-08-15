using Cake.DotNetTool.Module;
using Cake.Frosting;

namespace Syrinject.Build.Extensions;

internal static class ToolInstaller
{
    public static CakeHost InstallSyrinjectTools(this CakeHost host)
    {
        return host
            .UseModule<DotNetToolModule>()
            .InstallTool(new Uri("dotnet:?package=dotnet-reportgenerator-globaltool"));
    }
}
