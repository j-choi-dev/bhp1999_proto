using System;
using UniRx;

namespace CoreAssetUI.Presenter
{
    /// <summary>
    /// 결과 표시용 Modal의 IF
    /// @Auth Choi
    /// </summary>
    public interface IResultModal
    {
        IObservable<Unit> OnConfirm { get; }

        void SetActive( bool isActive );
    }
}
