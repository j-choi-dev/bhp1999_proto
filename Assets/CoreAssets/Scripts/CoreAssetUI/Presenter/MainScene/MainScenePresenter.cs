using GameSystemSDK.Common.Domain;
using UnityEngine;
using Zenject;
using GameSystemSDK.Common;
using Cysharp.Threading.Tasks;
using UniRx;
using GameSystemSDK.Sound;

namespace CoreAssetUI.Presenter
{
    public class MainScenePresenter : MonoBehaviour
    {
        private IGameSoundController _gameSoundController;

        [Inject]
        public void Initialize( IGameSoundController gameSoundController )
        {
            _gameSoundController = gameSoundController;
        }
        private void Awake()
        {
            _gameSoundController.PlayBGM( "bgm002" );
        }
    }
}
