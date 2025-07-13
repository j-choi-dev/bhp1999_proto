using CoreAssetUI.Presenter;
using CoreAssetUI.View;
using UnityEngine;
using Zenject;

namespace CoreAssetUI.Installer
{
    /// <summary>
    /// Main Scene UI�� �����Ͽ� �����ؾ� �� Instance/Component ���� Zenject Installer
    /// </summary>
    public class MainSceneUIInstaller : MonoInstaller<MainSceneUIInstaller>
    {
        [SerializeField] private StageSelectModal _stageSelectModal = null;
        [SerializeField] private BattleEnterConfirmModal _battleEnterConfirmModal = null;

        public override void InstallBindings()
        {
            Container
                .Bind<IStageSelectModal>()
                .FromInstance( _stageSelectModal );

            Container
                .Bind<IBattleEnterConfirmModal>()
                .FromInstance( _battleEnterConfirmModal );
        }
    }
}
