using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    public interface IStageSelectModal
    {
        IObservable<string> OnButtonClick { get; }
        void SetWorldName( string value );
        void SetAreaName( string value );
        void SetGuage( int value );
        void SetStageInfoList( IReadOnlyList<IStageInfoData> list );
    }
}
