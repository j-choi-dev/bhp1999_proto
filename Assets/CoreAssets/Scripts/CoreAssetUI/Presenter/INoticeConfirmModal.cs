using System;
using UniRx;

namespace CoreAssetUI.Presenter
{
    /// <summary>
    /// 주의/경고 표시 Modal UI의 IF
    /// @Auth Choi
    /// </summary>
    public interface INoticeConfirmModal
    {
        IObservable<Unit> OnConfirmClick { get; }
        void SetHeaderTitleWithoutNotify( string val );
        void SetMessageWithoutNotify( string val );
        void SetConfirmButtonWithoutNotify( string val );
        void Show( bool isShow );
    }
}
