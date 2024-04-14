using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    public interface IBattleInfoView
    {
        void SetHandCountWithoutNotify( int value );
        void SetDiscardCountWithoutNotify( int value );
        void SetGoldWithoutNotify( int value );
        void SetCircleWithoutNotify( int value );
        void SetManaWithoutNotify( int value );
    }
}
