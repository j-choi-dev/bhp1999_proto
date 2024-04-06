using CoreAssetUI.Presenter;
using CoreAssetUI.View;
using UnityEngine;
using Zenject;

namespace CoreAssetUI.Installer
{
    public class MainSceneUIInstaller : MonoInstaller<MainSceneUIInstaller>
    {
        [SerializeField] private MainSceneFooterMenuView _mainSceneFooterMenuView = null;
        public override void InstallBindings()
        {
            Container
                .Bind<IMainSceneFooterMenuView>()
                .FromInstance( _mainSceneFooterMenuView );
        }
    }
}
