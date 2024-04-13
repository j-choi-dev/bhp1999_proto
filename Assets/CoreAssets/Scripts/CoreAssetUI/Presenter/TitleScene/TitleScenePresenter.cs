using GameSystemSDK.Common.Domain;
using UnityEngine;
using Zenject;
using GameSystemSDK.Common;
using Cysharp.Threading.Tasks;
using UniRx;
using GameSystemSDK.Sound;

namespace CoreAssetUI.Presenter
{
    public class TitleScenePresenter : MonoBehaviour
    {
        private ITitleSceneView _titleSceneView;
        private ISceneController _sceneController;
        private IGameSoundController _gameSoundController;
        private SceneValueDomain _sceneValueDomain;

        [Inject]
        public void Initialize( ITitleSceneView titleSceneView,
            ISceneController sceneController,
            IGameSoundController gameSoundController)
        {
            _titleSceneView = titleSceneView;
            _sceneController = sceneController;
            _gameSoundController = gameSoundController;
            _sceneValueDomain = new SceneValueDomain();
        }

        private void Awake()
        {
            _gameSoundController.PlayBGM( "bgm001" );
            _titleSceneView.OnClickLogIn
                .Subscribe( async _ =>
                {
                    _gameSoundController.PlayEffect( "eff001" );
                    await UniTask.WaitUntil( () => _gameSoundController.IsPlayingEffect == false );
                    await _sceneController.LoadSceneAsync( _sceneValueDomain.MainSceneName );
                } )
                .AddTo( this );
        }
    }
}
