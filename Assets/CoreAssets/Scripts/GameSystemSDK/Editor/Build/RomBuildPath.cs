using System.IO;

namespace GameSystemSDK.Editor.Build.Domain
{
    /// <summary>
    /// 빌드 실행에 필요한 프롣 경로 등의 데이터 클래스
    /// @Auth Choi
    /// </summary>
    public static class RomBuildPath
    {
        public static readonly string ProjectRootPath = UnityEngine.Application.dataPath.Replace("Assets", string.Empty);
        public static readonly string BuildRomSubDirPath = "Builds/Rom/";
        public static readonly string RomExportRootPath = Path.Combine(ProjectRootPath, BuildRomSubDirPath);
    }
}
