using System;
using UniRx;

namespace CoreAssetUI.Presenter
{
    public interface IResultModal
    {
        IObservable<Unit> OnConfirm { get; }

        void SetActive( bool isActive );
    }
}
