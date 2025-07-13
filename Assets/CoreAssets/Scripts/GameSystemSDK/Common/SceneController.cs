using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using GameSystemSDK.Common.Domain;

namespace GameSystemSDK.Common
{
    /// <summary>
    /// Scene ��ȯ�� �����ϴ� Controller
    /// @Auth Choi
    /// </summary>
    public interface ISceneController
    {
        /// <summary>
        /// Async Scene Load
        /// </summary>
        /// <param name="sceneName">Scene �̸�</param>
        /// <returns>UniTask �̺�Ʈ</returns>
        UniTask LoadSceneAsync( string sceneName );

        /// <summary>
        /// �ܼ� Scene Load
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="isAddittive"></param>
        void LoadScene( string sceneName, bool isAddittive );

        /// <summary>
        /// Async Scene Unload
        /// </summary>
        /// <param name="sceneName">Unload�� Scene �̸�</param>
        /// <returns>UniTask �̺�Ʈ</returns>
        UniTask UnloadSceneAsync( string sceneName );
    }

    public class SceneController : ISceneController
    {
        private string _prevSceneName = string.Empty;
        private string _currSceneName = string.Empty;

        private SceneValueDomain _sceneDomain = null;

        public SceneController()
        {
            _sceneDomain = new SceneValueDomain();
        }

        public async UniTask LoadSceneAsync( string sceneName )
        {
            if(string.IsNullOrEmpty( _currSceneName ) == false )
            {
                _prevSceneName = _currSceneName;
            }
            _currSceneName = sceneName;
            SceneManager.LoadScene( _sceneDomain.EmptySceneName, LoadSceneMode.Additive );
            await SceneManager.LoadSceneAsync( _currSceneName, LoadSceneMode.Additive );
            if( string.IsNullOrEmpty( _prevSceneName ) == false )
            {
                await SceneManager.UnloadSceneAsync( _prevSceneName );
            }
            await SceneManager.UnloadSceneAsync( _sceneDomain.EmptySceneName );
            System.GC.Collect();
        }

        public void LoadScene( string sceneName, bool isAddittive )
        {
            var sceneMode = isAddittive ?
                LoadSceneMode.Additive :
                LoadSceneMode.Single;
            SceneManager.LoadScene( sceneName, sceneMode );
        }

        public async UniTask UnloadSceneAsync( string sceneName )
        {
            await SceneManager.UnloadSceneAsync( sceneName );
            System.GC.Collect();
        }
    }
}
