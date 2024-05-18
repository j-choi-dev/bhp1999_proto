using System.IO;

namespace StudioRomBuild.Editor.Domain
{
    public static class RomBuildPath
    {
        public static readonly string ProjectRootPath = UnityEngine.Application.dataPath.Replace("Assets", string.Empty);
        public static readonly string BuildRomSubDirPath = "Builds/Rom/";
        public static readonly string RomExportRootPath = Path.Combine(ProjectRootPath, BuildRomSubDirPath);
    }
}
