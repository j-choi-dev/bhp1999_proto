using GameSystemSDK.Common.Application;
using GameSystemSDK.Common.Domain;
using GameSystemSDK.Common.Infrastructure;
using GameSystemSDK.Common.Model;
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
    /// <summary>
    /// 게임 시스템 전체에 필요한 Instance를 Inject하는 Installer
    /// @Auth Choi
    /// </summary>
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
                .Bind<IGameConfigSettingModel>()
                .To<GameConfigSettingModel>()
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
                .Bind<IGameConfigSettingContext>()
                .To<GameConfigSettingContext>()
                .AsCached();


            Container
                .Bind<IExternalConnectDomain>()
                .To<ExternalConnector>()
                .AsCached();

            Container
                .Bind<IGameConfigSettingDomain>()
                .To<GameConfigSettingInfrastructure>()
                .AsCached();

            Container
                .Bind<ITextResourceConfig>()
                .FromInstance( _textResourceConfig );
        }
    }
}
