using Zenject;
using UnityEngine;
using CoreAssetUI.View;
using CoreAssetUI.Presenter;
using CoreAssetUI;

namespace GameSystemSDK.Battle.Installer
{
    public class BattleUIInstaller : MonoInstaller<BattleUIInstaller>
    {
        [SerializeField] private CardBoardView _handDeckListView;
        [SerializeField] private SelectedBoardView _selectedDeckListView;


        public override void InstallBindings()
        {
            // View 
            Container
                .Bind<ICardBoardView>()
                .FromInstance( _handDeckListView );
            Container
                .Bind<ISelectedBoardView>()
                .FromInstance( _selectedDeckListView );
        }
    }
}
