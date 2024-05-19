using System.Linq;
using UnityEditor;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using UnityEngine;
using UnityEditor.Build;
using GameSystemSDK.Editor.Build.Domain;

namespace GameSystemSDK.Editor.Build.Infrastructure
{
    public class IOSRomBuildInfrastructure : IRomBuildDomain
    {
        private string _folderName = string.Empty;
        private string _buildPath = string.Empty;
        private string _buildExtension = string.Empty;
        private BuildTarget _buildTarget = BuildTarget.NoTarget;
        private NamedBuildTarget _namedBuildTarget = NamedBuildTarget.Unknown;
        private IconKind _iconKind = default;

        public IOSRomBuildInfrastructure( string folderName )
        {
            _folderName = folderName;
            _buildTarget = BuildTarget.Android;
            _namedBuildTarget = NamedBuildTarget.Android;
            _buildExtension = "/XcodeProject";
            _iconKind = IconKind.Application | IconKind.Store;
        }

        public bool PreProcess()
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTargetGroup.iOS, BuildTarget.iOS );

            PlayerSettings.companyName = "NoCompany";
            PlayerSettings.productName = "BHP1999_proto";
            PlayerSettings.applicationIdentifier = "com.nocompany.bhp1999proto";
            if( PlayerSettings.defaultScreenWidth != 1080 )
            {
                PlayerSettings.defaultScreenWidth = 1080;
            }
            if( PlayerSettings.defaultScreenHeight != 1920 )
            {
                PlayerSettings.defaultScreenHeight = 1920;
            }
            if( PlayerSettings.fullScreenMode != FullScreenMode.FullScreenWindow )
            {
                PlayerSettings.fullScreenMode = FullScreenMode.FullScreenWindow;
            }
            if( Directory.Exists( _folderName ) == false )
            {
                Directory.CreateDirectory( _folderName );
            }
            _buildPath = $"{RomBuildPath.BuildRomSubDirPath}/{_folderName}/{_folderName}{_buildExtension}";

            var path = "Assets/CoreAssets/Scripts/GameSystemSDK/Editor/Build/AppIcon/icon.png";
            var icon = new Texture2D[] { ( Texture2D )AssetDatabase.LoadAssetAtPath( path, typeof( Texture2D ) ) };
            PlayerSettings.SetIcons( _namedBuildTarget, icon, _iconKind );
            return true;
        }

        public bool BuildProcess()
        {
            var scenes = EditorBuildSettings.scenes
                            .Where(scene => scene.enabled)
                            .Select(scene => scene.path)
                            .ToArray();

            var result = BuildPipeline.BuildPlayer( scenes, _buildPath, _buildTarget, BuildOptions.CompressWithLz4 );
            return result.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded;
        }

        public bool PostProcess()
        {
            var directory = Path.GetDirectoryName(_buildPath);
            var folderName = new DirectoryInfo(directory).Name;
            var zipPath = $"{RomBuildPath.RomExportRootPath}/{folderName}.zip";
            if( File.Exists( zipPath ) )
            {
                File.Delete( zipPath );
            }
            ZipFile.CreateFromDirectory( directory, zipPath );
            Process.Start( _buildPath );
            var icon = new Texture2D[] { };
            PlayerSettings.SetIcons( _namedBuildTarget, icon, _iconKind );
            PlayerSettings.applicationIdentifier = string.Empty;
            PlayerSettings.companyName = string.Empty;
            PlayerSettings.productName = string.Empty;
            return true;
        }
    }
}
