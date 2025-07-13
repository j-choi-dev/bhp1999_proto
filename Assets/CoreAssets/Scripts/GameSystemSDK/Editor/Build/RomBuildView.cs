using GameSystemSDK.Editor.Build.Application;
using GameSystemSDK.Editor.Build.Domain;
using GameSystemSDK.Editor.Build.Infrastructure;
using System.Linq;
using UnityEditor;

namespace GameSystemSDK.Editor.Build.View
{
    /// <summary>
    /// 빌드 메뉴 View & 외부 CI 실행을 위한 메소드 제공
    /// </summary>
    public static class RomBuildView
    {
        private const string BuildAndroidApplicationMenuName = "BHP1999_Tool/Rom Build/Build Android App";
        private const string BuildIOSApplicationMenuName = "BHP1999_Tool/Rom Build/Build IOS App";
        private const string BuildVersionKey = "/build_version";

        [MenuItem( BuildAndroidApplicationMenuName, priority = 11 )]
        private static async void BuildAndroidProcess()
        {
            if( EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android )
            {
                return;
            }
            UnityEngine.Debug.Log( $"CHOI :: BuildIOSProcess({EditorUserBuildSettings.activeBuildTarget})" );
            EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTargetGroup.Android, BuildTarget.Android );
            var buildVersion = PlayerSettings.bundleVersion;

            var buildFolder = $"BHP1999_{buildVersion}_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
            var folderName = System.IO.Path.Combine(RomBuildPath.RomExportRootPath, buildFolder);
            var adapter = new RomBundleAdapter( new AndroidRomBuildInfrastructure(folderName));
            adapter.BuildAssetBundle();
        }

        [MenuItem( BuildIOSApplicationMenuName, priority = 11 )]
        private static async void BuildIOSProcess()
        {
            if( EditorUserBuildSettings.activeBuildTarget != BuildTarget.iOS )
            {
                return;
            }
            EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTargetGroup.Android, BuildTarget.Android );
            var buildVersion = PlayerSettings.bundleVersion;

            var buildFolder = $"BHP1999_{buildVersion}_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
            var folderName = System.IO.Path.Combine(RomBuildPath.RomExportRootPath, buildFolder);
            var adapter = new RomBundleAdapter( new IOSRomBuildInfrastructure(folderName));
            adapter.BuildAssetBundle();
        }

        /// <summary>
        /// 외부 CI(Bash, cmd) 실행시 호출할 메소드
        /// </summary>
        private static void AndroidBuildProcessByExternal()
        {
            var rootPath = RomBuildPath.RomExportRootPath;

            var rawBuildVersion = System.Environment.GetCommandLineArgs()
                .SkipWhile(element => !element.Equals(BuildVersionKey))
                .Skip(1)
                .FirstOrDefault();
            var buildVersion = !string.IsNullOrEmpty(rawBuildVersion) ?
                rawBuildVersion :
                PlayerSettings.bundleVersion;

            var folderName = $"BHP1999_{buildVersion}_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
            var adapter = new RomBundleAdapter( new AndroidRomBuildInfrastructure(folderName) );
            adapter.BuildAssetBundle();
        }

        /// <summary>
        /// 외부 CI(Bash, cmd) 실행시 호출할 메소드
        /// </summary>
        private static void IOSBuildProcessByExternal()
        {
            var rawBuildVersion = System.Environment.GetCommandLineArgs()
                .SkipWhile(element => !element.Equals(BuildVersionKey))
                .Skip(1)
                .FirstOrDefault();
            var buildVersion = !string.IsNullOrEmpty(rawBuildVersion) ?
                rawBuildVersion :
                PlayerSettings.bundleVersion;

            var buildFolder = $"BHP1999_{buildVersion}_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
            var folderName = System.IO.Path.Combine(RomBuildPath.RomExportRootPath, buildFolder);
            var adapter = new RomBundleAdapter( new IOSRomBuildInfrastructure(folderName) );
            adapter.BuildAssetBundle();
        }
    }
}
