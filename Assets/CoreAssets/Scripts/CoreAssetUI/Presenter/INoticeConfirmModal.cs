using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    public interface INoticeConfirmModal
    {
        IObservable<Unit> OnConfirmClick { get; }
        void SetHeaderTitleWithoutNotify( string val );
        void SetMessageWithoutNotify( string val );
        void SetConfirmButtonWithoutNotify( string val );
        void Show( bool isShow );
    }
}
