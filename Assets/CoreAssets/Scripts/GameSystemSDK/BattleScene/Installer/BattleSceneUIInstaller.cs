using Zenject;
using GameSystemSDK.BattleScene.Model;
using GameSystemSDK.BattleScene.Application;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.BattleScene.Infrastructure;
using UnityEngine;
using CoreAssetUI.View;
using GameSystemSDK.Resource.Domain;
using GameSystemSDK.Resource.Infrastructure;
using CoreAssetUI.Presenter;

namespace GameSystemSDK.Battle.Installer
{
    public class BattleSceneUIInstaller : MonoInstaller<BattleSceneUIInstaller>
    {
        [SerializeField] private HandDeckListView _handDeckListView;
        [SerializeField] private SelectedCardListView _selectedCardListView;
        [SerializeField] private BattleInfoView _battleInfoView;
        [SerializeField] private RunControlView _runControlView;

        [SerializeField] private BattleResourceConfig _battleResourceConfig;
        public override void InstallBindings()
        {
            // View 
            Container
                .Bind<IHandDeckListView>()
                .FromInstance( _handDeckListView );

            Container
                .Bind<ISelectedCardListView>()
                .FromInstance( _selectedCardListView );

            Container
                .Bind<IBattleInfoView>()
                .FromInstance( _battleInfoView );

            Container
                .Bind<IRunControlView>()
                .FromInstance( _runControlView );


            // Model
            Container
                .Bind<ICardListModel>()
                .To<CardListModel>()
                .AsCached();

            Container
                .Bind<IGameProcessModel>()
                .To<GameProcessModel>()
                .AsCached();


            // Application
            Container
                .Bind<ICardListContext>()
                .To<CardListContext>()
                .AsCached();

            Container
                .Bind<ISelectedCardListContext>()
                .To<SelectedCardListContext>()
                .AsCached();

            Container
                .Bind<IHandCardListContext>()
                .To<HandCardListContext>()
                .AsCached();

            Container
                .Bind<ICardDeckListImportContext>()
                .To<CardDeckListImportContext>()
                .AsCached();

            Container
                .Bind<IGameRuleValueCntext>()
                .To<GameRuleValueCntext>()
                .AsCached();

            Container
                .Bind<IBattleInfoImporterContext>()
                .To<BattleInfoImporterContext>()
                .AsCached();


            // Domain & Infrastructure
            Container
                .Bind<ICardListDomain>()
                .To<CardListDomain>()
                .AsCached();

            Container
                .Bind<IHandCardListDomain>()
                .To<HandCardListDomain>()
                .AsCached();

            Container
                .Bind<ISelectedCardListDomain>()
                .To<SelectedCardListDomain>()
                .AsCached();

            Container
                .Bind<ICardDeckListImportDomain>()
                .To<CardDeckListImporter>()
                .AsCached();

            Container
                .Bind<IBattleResourceConfig>()
                .FromInstance( _battleResourceConfig );

            Container
                .Bind<IGameRuleValueDomain>()
                .To<GameRuleValueDomain>()
                .AsCached();

            Container
                .Bind<IBattleInfoImporterDomain>()
                .To<BattleInfoImporterInfrastructure>()
                .AsCached();
        }
    }
}
