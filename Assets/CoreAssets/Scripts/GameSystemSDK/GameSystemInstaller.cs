using GameSystemSDK.Sound;
using UnityEngine;
using Zenject;

namespace GameSystemSDK.Common.Installer
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        [SerializeField] private GameSoundController _gameSoundController = null;

        public override void InstallBindings()
        {
            Container
                .Bind<ISceneController>()
                .To<SceneController>()
                .AsCached();

            Container
                .Bind<IGameSoundController>()
                .FromInstance( _gameSoundController );
        }
    }
}
