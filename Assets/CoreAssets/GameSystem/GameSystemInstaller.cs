using GameSystem.Common;
using GameSystem.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CoreAssetUI.Installer
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
