using CoreAssetUI.View;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    public interface ICardBoardView
    {
        IObservable<(string id, bool isSelected)> OnCurrentSelectionIDChanged { get; }
        IObservable<IReadOnlyList<string>> OnCurrentSelectedIDListChanged { get; }
        IObservable<ICellBase> OnChangeSelectedCardList { get; }

        void Add( string id, Sprite sprite, bool isInActive );
        void Remove( string id );

        void SetMaxSelectionCount( int val );
    }
}
