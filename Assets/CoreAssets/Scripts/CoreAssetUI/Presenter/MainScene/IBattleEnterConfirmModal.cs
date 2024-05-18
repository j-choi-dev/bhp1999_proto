using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    public interface IBattleEnterConfirmModal
    {
        IObservable<Unit> OnPlayClick { get; }
        IObservable<Unit> OnSkipClick { get; }
        IObservable<Unit> OnCloseClick { get; }

        void SetActive( bool isVal );
        void SetGoalScore( string val );
        void SetGold( string val );
        void SetPlayCount( string val );
        void SetDiscardCount( string val );
    }
}
