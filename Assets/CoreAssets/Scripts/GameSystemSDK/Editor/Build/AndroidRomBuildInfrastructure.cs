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
    public class AndroidRomBuildInfrastructure : IRomBuildDomain
    {
        private string _rootPath = string.Empty;
        private string _buildFolder = string.Empty;
        private string _buildPath = string.Empty;
        private string _buildExtension = string.Empty;
        private string _version = string.Empty;
        private BuildTarget _buildTarget = BuildTarget.NoTarget;
        private NamedBuildTarget _namedBuildTarget = NamedBuildTarget.Unknown;
        private IconKind _iconKind = default;

        public AndroidRomBuildInfrastructure( string buildPath, string version )
        {
            _rootPath = buildPath;
            _version = version;
            _buildTarget = BuildTarget.Android;
            _namedBuildTarget = NamedBuildTarget.Android;
            _buildExtension = ".apk";
            _iconKind = IconKind.Application | IconKind.Store;
        }

        public bool PreProcess()
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTargetGroup.Android, BuildTarget.Android );

            PlayerSettings.companyName = "No Company";
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
            _buildPath = $"{_rootPath}/{UnityEngine.Application.productName}_{_version}{_buildExtension}";

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
            var icon = new Texture2D[] { };
            PlayerSettings.SetIcons( _namedBuildTarget, icon, _iconKind );
            PlayerSettings.applicationIdentifier = string.Empty;
            PlayerSettings.companyName = string.Empty;
            PlayerSettings.productName = string.Empty;
            return true;
        }
    }
}
