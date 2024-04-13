using GameSystemSDK.Sound;
using UnityEngine;
using Zenject;
using UniRx;
using GameSystemSDK.Common;
using Cysharp.Threading.Tasks;
using GameSystemSDK.Common.Domain;

namespace CoreAssetUI.Presenter
{
    public class MainSceneFooterMenuPresenter : MonoBehaviour
    {
        private IMainSceneFooterMenuView _mainSceneFooterMenuView;
        private IGameSoundController _gameSoundController;
        private ISceneController _sceneController;
        private SceneValueDomain _sceneValueDomain;

        [Inject]
        public void Initialize( IMainSceneFooterMenuView mainSceneFooterMenuView,
            ISceneController sceneController,
            IGameSoundController gameSoundController )
        {
            _mainSceneFooterMenuView = mainSceneFooterMenuView;
            _sceneController = sceneController;
            _gameSoundController = gameSoundController;
            _sceneValueDomain = new SceneValueDomain();
        }

        private void Awake()
        {
            _mainSceneFooterMenuView.OnClickEnterToGame
                .Subscribe( async _ =>
                {
                    _gameSoundController.PlayEffect( "eff002" );
                    await UniTask.WaitUntil( () => _gameSoundController.IsPlayingEffect == false );
                    await _sceneController.LoadSceneAsync( _sceneValueDomain.BattleSceneName );
                } )
                .AddTo( this );
        }
    }
}
