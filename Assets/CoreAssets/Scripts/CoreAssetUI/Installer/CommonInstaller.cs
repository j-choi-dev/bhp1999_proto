using GameSystemSDK.Common.Application;
using GameSystemSDK.Common.Domain;
using Zenject;

namespace CoreAssetUI.Installer
{
    /// <summary>
    /// App 기동중 상시 사용할 Instance를 주입하는 Zenject Installer
    /// @Auth Choi
    /// </summary>
    public class CommonInstaller : MonoInstaller<CommonInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IDataConvertContext>()
                .To<DataConvertContext>()
                .AsCached();

            Container
                .Bind<IDataConvertDomain>()
                .To<DataConvertDomain>()
                .AsCached();
        }
    }
}
