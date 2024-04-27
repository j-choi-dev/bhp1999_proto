using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public interface IDoubleTapCell : ICellBase
    {
        IObservable<Unit> OnDoubleSelected { get; }
        bool IsDoubleSelected { get; set; }
        void SetDoubleSelectWithoutNotify( bool isSelected );
    }
}
