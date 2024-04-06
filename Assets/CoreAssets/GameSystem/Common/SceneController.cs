using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using GameSystem.Common.Domain;

namespace GameSystem.Common
{
    public interface ISceneController
    {
        UniTask LoadSceneAsync( string sceneName );
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
        }
    }
}
