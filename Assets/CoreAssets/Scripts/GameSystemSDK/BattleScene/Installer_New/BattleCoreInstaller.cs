using Zenject;
using UnityEngine;
using CoreAssetUI.View;
using CoreAssetUI.Presenter;
using CoreAssetUI;
using GameSystemSDK.BattleScene.Model;
using GameSystemSDK.Card.Application;
using GameSystemSDK.Server.Apllication;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Server.Infrastructure;
using GameSystemSDK.Server.Domain;
using GameSystemSDK.Card.Domain;
using IHandCardListDomain = GameSystemSDK.Card.Domain.IHandCardListDomain;
using ISelectedCardListDomain = GameSystemSDK.Card.Domain.ISelectedCardListDomain;
using GameSystemSDK.Card.Infrastructure;
using GameSystemSDK.Resource.Infrastructure;
using GameSystemSDK.Resource.Domain;
using GameSystemSDK.BattleScene.Application;

namespace GameSystemSDK.Battle.Installer
{
    public class BattleCoreInstaller : MonoInstaller<BattleCoreInstaller>
    {
        [SerializeField] private BattleResourceConfig _battleResourceConfig = null;
        [SerializeField] private CardResourceConfig _cardResourceConfig = null;

        public override void InstallBindings()
        {
            // Model
            #region
            Container
                .Bind<IBattleCardModel>()
                .To<BattleCardModel>()
                .AsCached();
            Container
                .Bind<IBattleResourceModel>()
                .To<BattleResourceModel>()
                .AsCached();
            #endregion

            // Application
            #region
            Container
                .Bind<IBattleCardListContext>()
                .To<BattleCardListContext>()
                .AsCached();
            Container
                .Bind<IUserItemDataNetworkContext>()
                .To<UserItemDataNetworkContext>()
                .AsCached();
            Container
                .Bind<IBattleCardFactoryContext>()
                .To<BattleCardFactoryContext>()
                .AsCached();
            Container
                .Bind<IBattleResourceContext>()
                .To<BattleResourceContext>()
                .AsCached();
            #endregion

            // Domain
            #region
            Container
                .Bind<IHandCardListDomain>()
                .To<HandCardListStorage>()
                .AsCached();
            Container
                .Bind<ISelectedCardListDomain>()
                .To<SelectedCardListStorage>()
                .AsCached();
            Container
                .Bind<IUserItemDataSenderDomain>()
                .To<UserItemDataSender>()
                .AsCached();
            Container
                .Bind<IUserItemDataReceiverDomain>()
                .To<UserItemDataReceiverMock>() // TODO @Choi Mock
                .AsCached();
            Container
                .Bind<IBattleCardFactory>()
                .To<BattleCardFactory>()
                .AsCached();
            Container
                .Bind<IBattleResourceConfig>()
                .FromInstance( _battleResourceConfig )
                .AsCached();
            Container
                .Bind<ICardResourceConfig>()
                .FromInstance( _cardResourceConfig )
                .AsCached();
            #endregion
        }
    }
}
