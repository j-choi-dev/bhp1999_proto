using Zenject;
using GameSystemSDK.BattleScene.Model;
using GameSystemSDK.BattleScene.Application;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.BattleScene.Infrastructure;
using UnityEngine;
using GameSystemSDK.Resource.Domain;
using GameSystemSDK.Resource.Infrastructure;

namespace GameSystemSDK.Battle.Installer
{
    public class BattleSceneCoreInstaller : MonoInstaller<BattleSceneCoreInstaller>
    {
        [SerializeField] private BattleResourceConfig _battleResourceConfig;

        public override void InstallBindings()
        {
            // Model
            #region
            Container
                .Bind<ICardListModel>()
                .To<CardListModel>()
                .AsCached();

            Container
                .Bind<IGameProcessModel>()
                .To<GameProcessModel>()
                .AsCached();

            Container
                .Bind<IBattleResourceModel>()
                .To<BattleResourceModel>()
                .AsCached();

            Container
                .Bind<IBattleEffectModel>()
                .To<BattleEffectModel>()
                .AsCached();
            #endregion


            // Application
            #region
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
                .Bind<IBattleInfoContext>()
                .To<BattleInfoContext>()
                .AsCached();

            Container
                .Bind<IBattleResourceContext>()
                .To<BattleResourceContext>()
                .AsCached();

            Container
                .Bind<IHandScoreCalcurateContext>()
                .To<HandScoreCalcurateContext>()
                .AsCached();

            Container
                .Bind<IBattleEffectContext>()
                .To<BattleEffectContext>()
                .AsCached();
            #endregion


            // Domain & Infrastructure
            #region
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
                .Bind<ICardDeckListGenerateDomain>()
                .To<CardDeckListGenerator>()
                .AsCached();

            Container
                .Bind<IBattleResourceConfig>()
                .FromInstance( _battleResourceConfig );

            Container
                .Bind<IGameRuleValueDomain>()
                .To<GameRuleValueDomain>()
                .AsCached();

            Container
                .Bind<IStageInfoImporterDomain>()
                .To<StageInfoImporterInfrastructure>()
                .AsCached();

            Container
                .Bind<IHandDataListStorageDomain>()
                .To<HandDataListStorage>()
                .AsCached();

            Container
                .Bind<IHandScoreCalcuratorDomain>()
                .To<HandScoreCalcurator>()
                .AsCached();

            Container
                .Bind<IBattleEffectLaunchDomain>()
                .To<BattleEffectLaunch>()
                .AsCached();
            #endregion
        }
    }
}
