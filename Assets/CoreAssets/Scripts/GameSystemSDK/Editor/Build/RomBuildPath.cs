using System.IO;

namespace GameSystemSDK.Editor.Build.Domain
{
    /// <summary>
    /// ���� ���࿡ �ʿ��� ���� ��� ���� ������ Ŭ����
    /// @Auth Choi
    /// </summary>
    public static class RomBuildPath
    {
        public static readonly string ProjectRootPath = UnityEngine.Application.dataPath.Replace("Assets", string.Empty);
        public static readonly string BuildRomSubDirPath = "Builds/Rom/";
        public static readonly string RomExportRootPath = Path.Combine(ProjectRootPath, BuildRomSubDirPath);
    }
}
