using GameSystemSDK.Common.Application;
using GameSystemSDK.Common.Domain;
using Zenject;

namespace CoreAssetUI.Installer
{
    /// <summary>
    /// App �⵿�� ��� ����� Instance�� �����ϴ� Zenject Installer
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
