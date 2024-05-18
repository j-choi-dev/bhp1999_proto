using GameSystemSDK.Common;
using GameSystemSDK.Common.Domain;
using GameSystemSDK.Server.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CoreAssetUI.Presenter
{
    public class DefaultScenePresenter : MonoBehaviour
    {
        private ISceneController _sceneController;
        private IExternalConnectModel _externalConnectModel;
        private SceneValueDomain _sceneValueDomain;

        [Inject]
        public void Initialize( ISceneController sceneController,
            IExternalConnectModel externalConnectModel)
        {
            _sceneController = sceneController;
            _externalConnectModel = externalConnectModel;
            _sceneValueDomain = new SceneValueDomain();
        }

        private async void Start()
        {
            await _externalConnectModel.Initialize();
            await _sceneController.LoadSceneAsync( _sceneValueDomain.TitleSceneName );
        }
    }
}
