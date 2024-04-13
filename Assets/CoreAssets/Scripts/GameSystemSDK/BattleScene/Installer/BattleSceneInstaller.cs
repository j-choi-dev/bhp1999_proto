using Zenject;
using GameSystemSDK.BattleScene.Model;
using GameSystemSDK.BattleScene.Application;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.BattleScene.Infrastructure;
using UnityEngine;
using CoreAssetUI.View;
using GameSystemSDK.Resource.Domain;
using GameSystemSDK.Resource.Infrastructure;

namespace GameSystemSDK.Battle.Installer
{
    public class BattleSceneInstaller : MonoInstaller<BattleSceneInstaller>
    {
        [SerializeField] private HandDeckListView _handDeckListView;

        [SerializeField] private BattleResourceConfig _battleResourceConfig;
        public override void InstallBindings()
        {
            // View 
            Container
                .Bind<IHandDeckListView>()
                .FromInstance( _handDeckListView );

            // Model
            Container
                .Bind<ICardDeckModel>()
                .To<CardDeckModel>()
                .AsCached();


            // Application
            Container
                .Bind<ICardListContext>()
                .To<CardListContext>()
                .AsCached();
            Container
                .Bind<ICardDeckListImportContext>()
                .To<CardDeckListImportContext>()
                .AsCached();


            // Domain & Infrastructure
            Container
                .Bind<ICardListDomain>()
                .To<CardListDomain>()
                .AsCached();

            Container
                .Bind<ICardDeckListImportDomain>()
                .To<CardDeckListImporter>()
                .AsCached();

            Container
                .Bind<IBattleResourceConfig>()
                .FromInstance( _battleResourceConfig );
        }
    }
}
