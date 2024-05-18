using GameSystemSDK.Resource.Application;
using GameSystemSDK.Resource.Domain;
using GameSystemSDK.Resource.Infrastructure;
using GameSystemSDK.Server.Application;
using GameSystemSDK.Server.Domain;
using GameSystemSDK.Server.Infrastructure;
using GameSystemSDK.Server.Model;
using GameSystemSDK.Sound;
using UnityEngine;
using Zenject;

namespace GameSystemSDK.Common.Installer
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        [SerializeField] private GameSoundController _gameSoundController = null;
        [SerializeField] private TextResourceConfig _textResourceConfig = null;

        public override void InstallBindings()
        {
            Container
                .Bind<ISceneController>()
                .To<SceneController>()
                .AsCached();

            Container
                .Bind<IGameSoundController>()
                .FromInstance( _gameSoundController );

            Container
                .Bind<IExternalConnectModel>()
                .To<ExternalConnectModel>()
                .AsCached();


            Container
                .Bind<IExternalConnectContext>()
                .To<ExternalConnectContext>()
                .AsCached();

            Container
                .Bind<ILocalResourceFileLoadContext>()
                .To<LocalResourceFileLoadContext>()
                .AsCached();


            Container
                .Bind<IExternalConnectDomain>()
                .To<ExternalConnector>()
                .AsCached();

            Container
                .Bind<ITextResourceConfig>()
                .FromInstance( _textResourceConfig );
        }
    }
}
