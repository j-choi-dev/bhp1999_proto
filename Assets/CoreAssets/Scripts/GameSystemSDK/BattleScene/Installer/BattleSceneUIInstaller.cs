using Zenject;
using UnityEngine;
using CoreAssetUI.View;
using CoreAssetUI.Presenter;

namespace GameSystemSDK.Battle.Installer
{
    public class BattleSceneUIInstaller : MonoInstaller<BattleSceneUIInstaller>
    {
        [SerializeField] private HandDeckListView _handDeckListView;
        //[SerializeField] private SelectedCardListView _selectedCardListView;
        [SerializeField] private StaticCountListView _selectedCardListView;
        [SerializeField] private BattleInfoView _battleInfoView;
        [SerializeField] private RunControlView _runControlView;
        [SerializeField] private NoticeConfirmModal _noticeConfirmModal;

        public override void InstallBindings()
        {
            // View 
            Container
                .Bind<IHandDeckListView>()
                .FromInstance( _handDeckListView );

            //Container
            //    .Bind<ISelectedCardListView>()
            //    .FromInstance( _selectedCardListView );
            Container
                .Bind<IStaticCountListView>()
                .FromInstance( _selectedCardListView );

            Container
                .Bind<IBattleInfoView>()
                .FromInstance( _battleInfoView );

            Container
                .Bind<IRunControlView>()
                .FromInstance( _runControlView );

            Container
                .Bind<INoticeConfirmModal>()
                .FromInstance( _noticeConfirmModal );
        }
    }
}
