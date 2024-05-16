using System;
using UniRx;

namespace CoreAssetUI.Presenter
{
    public interface IShopModal
    {
        IObservable<Unit> OnGoToNextStage { get; }

        void SetActive(bool isActive);
    }
}
