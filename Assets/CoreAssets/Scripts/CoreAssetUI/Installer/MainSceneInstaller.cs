using GameSystemSDK.Stage.Application;
using GameSystemSDK.Stage.Domain;
using GameSystemSDK.Stage.Model;
using Zenject;

namespace CoreAssetUI.Installer
{
    /// <summary>
    /// Main Scene���� �ʿ�� �ϴ� Instance/Compoenent ������ ���� Zenject Installer
    /// </summary>
    public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IStageInfoDataModel>()
                .To<StageInfoDataModel>()
                .AsCached();

            Container
                .Bind<IStageInfoDataContext>()
                .To<StageInfoDataContext>()
                .AsCached();

            Container
                .Bind<IStageInfoListDomain>()
                .To<StageInfoListDomain>()
                .AsCached();
        }
    }
}
