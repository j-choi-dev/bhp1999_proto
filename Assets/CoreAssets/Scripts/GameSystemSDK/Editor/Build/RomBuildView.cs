using GameSystemSDK.Editor.Build.Application;
using GameSystemSDK.Editor.Build.Domain;
using GameSystemSDK.Editor.Build.Infrastructure;
using System.Linq;
using UnityEditor;

namespace GameSystemSDK.Editor.Build.View
{
    public static class RomBuildView
    {
        private const string BuildAndroidApplicationMenuName = "BHP1999_Tool/Rom Build/Build Android App";
        private const string BuildIOSApplicationMenuName = "BHP1999_Tool/Rom Build/Build IOS App";
        private const string BuildVersionKey = "/build_version";

        [MenuItem( BuildAndroidApplicationMenuName, priority = 11 )]
        private static async void BuildAndroidProcess()
        {
            UnityEngine.Debug.Log( $"CHOI :: BuildIOSProcess({EditorUserBuildSettings.activeBuildTarget})" );
            EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTargetGroup.Android, BuildTarget.Android );
            var buildVersion = PlayerSettings.bundleVersion;

            var buildFolder = $"BHP1999_{buildVersion}_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
            var exportDirPath = System.IO.Path.Combine(RomBuildPath.RomExportRootPath, buildFolder);
            var adapter = new RomBundleAdapter( new AndroidRomBuildInfrastructure(exportDirPath, buildVersion));
            adapter.BuildAssetBundle();
        }

        [MenuItem( BuildIOSApplicationMenuName, priority = 11 )]
        private static async void BuildIOSProcess()
        {
            UnityEngine.Debug.Log( $"CHOI :: BuildIOSProcess({EditorUserBuildSettings.activeBuildTarget})" );
            EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTargetGroup.Android, BuildTarget.Android );
            var buildVersion = PlayerSettings.bundleVersion;

            var buildFolder = $"BHP1999_{buildVersion}_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
            var exportDirPath = System.IO.Path.Combine(RomBuildPath.RomExportRootPath, buildFolder);
            var adapter = new RomBundleAdapter( new IOSRomBuildInfrastructure(exportDirPath, buildVersion));
            adapter.BuildAssetBundle();
        }

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

            var exportDirPath = $"BHP1999_{buildVersion}_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
            var adapter = new RomBundleAdapter( new AndroidRomBuildInfrastructure(exportDirPath, buildVersion) );
            adapter.BuildAssetBundle();
        }

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
            var exportDirPath = System.IO.Path.Combine(RomBuildPath.RomExportRootPath, buildFolder);
            var adapter = new RomBundleAdapter( new IOSRomBuildInfrastructure(exportDirPath, buildVersion) );
            adapter.BuildAssetBundle();
        }
    }
}
