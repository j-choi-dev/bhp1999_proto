using CoreAssetUI.Presenter;
using CoreAssetUI.View;
using UnityEngine;
using Zenject;

namespace CoreAssetUI.Installer
{
    public class TitleSceneUIInstaller : MonoInstaller<MainSceneUIInstaller>
    {
        [SerializeField] private TitleSceneView _titleSceneView = null;
        public override void InstallBindings()
        {
            Container
                .Bind<ITitleSceneView>()
                .FromInstance( _titleSceneView );
        }
    }
}
