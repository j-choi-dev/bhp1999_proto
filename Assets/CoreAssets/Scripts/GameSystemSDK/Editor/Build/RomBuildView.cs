using GameSystemSDK.Editor.Build.Application;
using GameSystemSDK.Editor.Build.Domain;
using GameSystemSDK.Editor.Build.Infrastructure;
using System.Linq;
using UnityEditor;

namespace GameSystemSDK.Editor.Build.View
{
    public static class RomBuildView
    {
        private const string BuildApplicationMenuName = "BHP1999_Tool/Rom Build/Build App";
        private const string TargetPlatform = "/target_platform";
        private const string RootPathKey = "/root_path";
        private const string BuildVersionKey = "/build_version";

        [MenuItem( BuildApplicationMenuName, priority = 11 )]
        private static async void BuildProcess()
        {
            var version = await RomBuildWindow.GetVersion();
            if( string.IsNullOrEmpty( version ) )
            {
                return;
            }

            PlayerSettings.bundleVersion = version;
            var buildFolder = $"BHP1999_{version}";
            var exportDirPath = System.IO.Path.Combine(RomBuildPath.RomExportRootPath, buildFolder);
            var adapter = new RomBundleAdapter( new AndroidRomBuildInfrastructure(exportDirPath));
            adapter.BuildAssetBundle();
        }

        private static async void AndroidBuildProcessByExternal()
        {
            var rawRootPath = System.Environment.GetCommandLineArgs()
                .SkipWhile(element => !element.Equals(RootPathKey))
                .Skip(1)
                .FirstOrDefault();
            var rootPath = !string.IsNullOrEmpty(rawRootPath) ?
                rawRootPath :
                RomBuildPath.RomExportRootPath;

            var rawBuildVersion = System.Environment.GetCommandLineArgs()
                .SkipWhile(element => !element.Equals(BuildVersionKey))
                .Skip(1)
                .FirstOrDefault();
            var buildVersion = !string.IsNullOrEmpty(rawBuildVersion) ?
                rawBuildVersion :
                PlayerSettings.bundleVersion;

            var dateTIme = System.DateTime.Now.ToString( "yyyyMMdd_HHmmss" );

            var buildFolder = $"BHP1999_{buildVersion}_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}";

            var exportDirPath = System.IO.Path.Combine(rootPath, buildFolder);
            var adapter = new RomBundleAdapter( new AndroidRomBuildInfrastructure(exportDirPath) );
        }

        private static async void IOSBuildProcessByExternal()
        {
            var rawRootPath = System.Environment.GetCommandLineArgs()
                .SkipWhile(element => !element.Equals(RootPathKey))
                .Skip(1)
                .FirstOrDefault();
            var rootPath = !string.IsNullOrEmpty(rawRootPath) ?
                rawRootPath :
                RomBuildPath.RomExportRootPath;

            var rawBuildVersion = System.Environment.GetCommandLineArgs()
                .SkipWhile(element => !element.Equals(BuildVersionKey))
                .Skip(1)
                .FirstOrDefault();
            var buildVersion = !string.IsNullOrEmpty(rawBuildVersion) ?
                rawBuildVersion :
                PlayerSettings.bundleVersion;

            var dateTIme = System.DateTime.Now.ToString( "yyyyMMdd_HHmmss" );

            var buildFolder = $"BHP1999_{buildVersion}_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}";

            var exportDirPath = System.IO.Path.Combine(rootPath, buildFolder);
            var adapter = new RomBundleAdapter( new IOSRomBuildInfrastructure(exportDirPath) );
        }
    }
}
