using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    public interface ITitleSceneView
    {
        IObservable<Unit> OnClickLogIn { get; }

        void SetVersionInfo( string value );
        void SetGUIDInfo( string value );
    }
}
