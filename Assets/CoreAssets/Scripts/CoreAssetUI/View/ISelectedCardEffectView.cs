using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.View
{
    public interface ISelectedCardEffectView
    {
        IReadOnlyList<ICellBase> PivotList { get; }
    }
}
