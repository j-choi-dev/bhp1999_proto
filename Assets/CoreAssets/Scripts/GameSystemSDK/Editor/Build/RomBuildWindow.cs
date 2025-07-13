using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace GameSystemSDK.Editor.Build.View
{
    /// <summary>
    /// Version명 지정 등을 수동으로 할 경우 사용할 Editor View
    /// @Auth Choi
    /// </summary>
    public class RomBuildWindow : EditorWindow
    {
        public bool DateTimeNow { get; private set; }
        public string Version { get; private set; }
        public bool Build { get; private set; }
        public bool Cancel { get; private set; }

        public static async UniTask<string> GetVersion()
        {
            var window = RomBuildWindow.GetWindow<RomBuildWindow>( true );
            await UniTask.WaitUntil( () => window.Build || window.Cancel );
            try
            {
                if( window != null && window.Build )
                {
                    if( window.DateTimeNow )
                    {
                        return System.DateTime.Now.ToString( "yyyyMMdd_HHmmss" );
                    }
                    else
                    {
                        return window.Version;
                    }
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                if( window != null )
                {
                    window.Close();
                }
            }
        }

        private void OnEnable()
        {
            Build = false;
            Cancel = false;
        }

        private void OnDisable()
        {
            Cancel = true;
        }

        private void OnGUI()
        {
            DateTimeNow = EditorGUILayout.Toggle( "DateTime.Now", DateTimeNow );
            using (var dis = new EditorGUI.DisabledGroupScope( DateTimeNow ) )
            {
                Version = EditorGUILayout.TextField( "Version", Version );
            }
            using( var hor = new GUILayout.HorizontalScope() )
            {
                if( GUILayout.Button( "Build" ) )
                {
                    Build = true;
                }
                if( GUILayout.Button( "Cancel" ) )
                {
                    Cancel = true;
                }
            }
        }
    }
}
