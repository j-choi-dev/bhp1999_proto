using StudioRomBuild.Editor.Application;
using StudioRomBuild.Editor.Infrastructure;
using StudioRomBuild.Editor.Domain;
using System.Linq;
using UnityEditor;

namespace StudioRomBuild.Editor.View
{
    public static class RomBuildView
    {
        private const string BuildApplicationMenuName = "BHP1999_Tool/Rom Build/Build App";
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
            var adapter = new RomBundleAdapter( new RomBuildInfrastructure(exportDirPath));
            adapter.BuildAssetBundle();
        }

        private static async void BuildProcessByExternal()
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
            var adapter = new RomBundleAdapter( new RomBuildInfrastructure(exportDirPath));
        }
    }
}
