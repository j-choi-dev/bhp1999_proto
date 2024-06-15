using CoreAssetUI.View;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    public interface ISelectedBoardView
    {
        public IObservable<(string id, bool isSelected)> OnCurrentSelectionIDChanged { get; }
        public IObservable<IReadOnlyList<string>> OnCurrentSelectedIDListChanged { get; }
        public IObservable<ICellBase> OnChangeSelectedCardList { get; }

        public void Add( string id, string title, Sprite sprite, bool isInActive );
        void Remove( string id );
        void Clear();
    }
}
