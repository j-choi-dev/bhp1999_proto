using GameSystemSDK.Common;
using GameSystemSDK.Common.Domain;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CoreAssetUI.Presenter
{
    public class DefaultScenePresenter : MonoBehaviour
    {
        private ISceneController _sceneController;
        private SceneValueDomain _sceneValueDomain;

        [Inject]
        public void Initialize( ISceneController sceneController )
        {
            _sceneController = sceneController;
            _sceneValueDomain = new SceneValueDomain();
        }

        private async void Start()
        {
            await _sceneController.LoadSceneAsync( _sceneValueDomain.TitleSceneName );
        }
    }
}
