using System;
using UniRx;

namespace CoreAssetUI.Presenter
{
    public interface IRunControlView
    {
        IObservable<Unit> OnHandPlayButton { get; }
        IObservable<Unit> OnDiscardButton { get; }
        void SetHandPlayInteractable( bool isValue );
        void SetDiscardInteractable( bool isValue );
    }
}
