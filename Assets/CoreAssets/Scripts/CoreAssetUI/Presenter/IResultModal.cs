using System;
using UniRx;

namespace CoreAssetUI.Presenter
{
    /// <summary>
    /// ��� ǥ�ÿ� Modal�� IF
    /// @Auth Choi
    /// </summary>
    public interface IResultModal
    {
        IObservable<Unit> OnConfirm { get; }

        void SetActive( bool isActive );
    }
}
