using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    /// <summary>
    /// 게임 진행 정보에 관련된 View
    /// @Auth Choi
    /// </summary>
    public interface IBattleInfoView
    {
        bool IsScorePlateOn { get; }
        void SetHandCountWithoutNotify( int value );
        void SetDiscardCountWithoutNotify( int value );
        void SetGoldWithoutNotify( int value );
        void SetGoalScoreWithoutNotify( int value );
        void SetCircleWithoutNotify( int value );
        void SetManaWithoutNotify( int value );
        void SetDeckCountWithoutNotify( int numerator, int denominator );
        void SetScorePlateWithoutNotify( string value );
        void SetScorePlateOn( bool isOn );
        void SetScorePercentageWithoutNotify( int value );
    }
}
