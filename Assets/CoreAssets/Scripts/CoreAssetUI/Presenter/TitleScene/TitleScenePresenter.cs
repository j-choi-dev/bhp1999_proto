using GameSystemSDK.Common.Domain;
using UnityEngine;
using Zenject;
using GameSystemSDK.Common;
using Cysharp.Threading.Tasks;
using UniRx;
using GameSystemSDK.Sound;
using GameSystemSDK.Server.Model;

namespace CoreAssetUI.Presenter
{
    public class TitleScenePresenter : MonoBehaviour
    {
        private ITitleSceneView _titleSceneView;
        private ISceneController _sceneController;
        private IGameSoundController _gameSoundController;
        private IExternalConnectModel _externalConnectModel;

        private SceneValueDomain _sceneValueDomain;

        [Inject]
        public void Initialize( ITitleSceneView titleSceneView,
            ISceneController sceneController,
            IGameSoundController gameSoundController,
            IExternalConnectModel externalConnectModel )
        {
            _titleSceneView = titleSceneView;
            _sceneController = sceneController;
            _gameSoundController = gameSoundController;
            _externalConnectModel = externalConnectModel;
            _sceneValueDomain = new SceneValueDomain();
        }

        private async void Awake()
        {
            _gameSoundController.PlayBGM( "bgm001" );
            _titleSceneView.SetVersionInfo( "prop_0.1" );

            var guid = await _externalConnectModel.GetID();
            _titleSceneView.SetGUIDInfo( guid );

            _titleSceneView.OnClickLogIn
                .Subscribe( async _ =>
                {
                    _gameSoundController.PlayEffect( "eff001" );
                    _externalConnectModel.UpdateLogInTime();
                    await UniTask.WaitUntil( () => _gameSoundController.IsPlayingEffect == false );
                    await _sceneController.LoadSceneAsync( _sceneValueDomain.MainSceneName );
                } )
                .AddTo( this );
        }
    }
}
