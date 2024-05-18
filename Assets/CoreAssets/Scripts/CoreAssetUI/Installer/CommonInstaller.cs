using GameSystemSDK.Common.Application;
using GameSystemSDK.Common.Domain;
using GameSystemSDK.Stage.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CoreAssetUI.Installer
{

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
