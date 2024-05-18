using GameSystemSDK.Common.Application;
using GameSystemSDK.Stage.Application;
using GameSystemSDK.Stage.Domain;
using GameSystemSDK.Stage.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CoreAssetUI.Installer
{
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
