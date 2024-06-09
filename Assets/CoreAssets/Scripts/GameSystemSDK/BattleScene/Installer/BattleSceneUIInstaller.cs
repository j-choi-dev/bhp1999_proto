using Zenject;
using UnityEngine;
using CoreAssetUI.View;
using CoreAssetUI.Presenter;
using CoreAssetUI;

namespace GameSystemSDK.Battle.Installer
{
    public class BattleSceneUIInstaller : MonoInstaller<BattleSceneUIInstaller>
    {
        [SerializeField] private HandDeckListView _handDeckListView;
        [SerializeField] private SelectedCardListView _selectedCardListView;
        [SerializeField] private BattleInfoView _battleInfoView;
        [SerializeField] private RunControlView _runControlView;
        [SerializeField] private ResultModal _resultModal;
        [SerializeField] private ShopModal _shopModal;
        [SerializeField] private NoticeConfirmModal _noticeConfirmModal;
        [SerializeField] private BattleSceneActivationView _activationView;

        // New in Here
        [SerializeField] private ListView _handDeckListView_;
        [SerializeField] private ListView _selectedDeckListView_;

        //public override void InstallBindings()
        //{
        //    // View 
        //    Container
        //        .Bind<IHandDeckListView>()
        //        .FromInstance( _handDeckListView );

        //    Container
        //        .Bind<ISelectedCardListView>()
        //        .FromInstance( _selectedCardListView );

        //    Container
        //        .Bind<IBattleInfoView>()
        //        .FromInstance( _battleInfoView );

        //    Container
        //        .Bind<IRunControlView>()
        //        .FromInstance( _runControlView );

        //    Container
        //        .Bind<INoticeConfirmModal>()
        //        .FromInstance( _noticeConfirmModal );

        //    Container
        //        .Bind<IResultModal>()
        //        .FromInstance( _resultModal );

        //    Container
        //        .Bind<IShopModal>()
        //        .FromInstance( _shopModal );

        //    Container
        //        .Bind<IBattleSceneActivationView>()
        //        .FromInstance( _activationView );
        //}

        public override void InstallBindings()
        {
            // View 
            Container
                .Bind<IListView>()
                .WithId( BindingID.HandDeckListView )
                .FromInstance( _selectedDeckListView_ );
            Container
                .Bind<IListView>()
                .WithId( BindingID.SelectedListView )
                .FromInstance( _handDeckListView_ );

            Container
                .Bind<ISelectedCardListView>()
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

            Container
                .Bind<IResultModal>()
                .FromInstance( _resultModal );

            Container
                .Bind<IShopModal>()
                .FromInstance( _shopModal );

            Container
                .Bind<IBattleSceneActivationView>()
                .FromInstance( _activationView );
        }

    }
}
