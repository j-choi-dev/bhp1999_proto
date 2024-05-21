using GameSystemSDK.Common;
using GameSystemSDK.Common.Domain;
using GameSystemSDK.Common.Model;
using GameSystemSDK.Server.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CoreAssetUI.Presenter
{
    public class CoreScenePresenter : MonoBehaviour
    {
        private ISceneController _sceneController;
        private IExternalConnectModel _externalConnectModel;
        private IGameConfigSettingModel _gameConfigSettingModel;
        private SceneValueDomain _sceneValueDomain;

        [Inject]
        public void Initialize( ISceneController sceneController,
            IExternalConnectModel externalConnectModel,
            IGameConfigSettingModel gameConfigSettingModel )
        {
            _sceneController = sceneController;
            _externalConnectModel = externalConnectModel;
            _gameConfigSettingModel=gameConfigSettingModel;
            _sceneValueDomain = new SceneValueDomain();
        }

        private void Awake()
        {
            _gameConfigSettingModel.SetGameSetting();
        }

        private async void Start()
        {
            await _externalConnectModel.Initialize();
            await _sceneController.LoadSceneAsync( _sceneValueDomain.TitleSceneName );
        }
    }
}
