using System;
using UniRx;

namespace CoreAssetUI.Presenter
{
    /// <summary>
    /// Shop UI Modal
    /// @Auth Choi
    /// </summary>
    public interface IShopModal
    {
        IObservable<Unit> OnGoToNextStage { get; }

        void SetActive(bool isActive);
    }
}
