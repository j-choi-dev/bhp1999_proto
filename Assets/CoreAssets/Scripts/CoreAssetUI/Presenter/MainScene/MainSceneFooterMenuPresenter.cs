using GameSystem.Sound;
using UnityEngine;
using Zenject;
using UniRx;

namespace CoreAssetUI.Presenter
{
    public class MainSceneFooterMenuPresenter : MonoBehaviour
    {
        private IMainSceneFooterMenuView _mainSceneFooterMenuView;
        private IGameSoundController _gameSoundController;

        [Inject]
        public void Initialize( IMainSceneFooterMenuView mainSceneFooterMenuView,
            IGameSoundController gameSoundController )
        {
            _mainSceneFooterMenuView = mainSceneFooterMenuView;
            _gameSoundController = gameSoundController;
        }

        private void Awake()
        {
            _mainSceneFooterMenuView.OnClickEnterToGame
                .Subscribe( _ =>
                {
                    _gameSoundController.PlayEffect( "eff002" );
                    Debug.Log( "// TODO インゲームシーン遷移  Here @Choi 24.04.06" );
                 } )
                .AddTo( this );
        }
    }
}
