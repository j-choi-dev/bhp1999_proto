using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    public interface IMainSceneFooterMenuView
    {
        IObservable<Unit> OnClickEnterToGame { get; }
    }
}
