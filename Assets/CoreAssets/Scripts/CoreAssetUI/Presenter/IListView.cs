using CoreAssetUI.View;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    public interface IListView
    {
        IReadOnlyList<ICellBase> Cells { get; }
        string CurrentSelectedID { get; }

        IObservable<int> OnListCountChanged { get; }
        IObservable<(string id, bool isSelected)> OnSelectionIDChanged { get; }
        IObservable<(int index, bool isSelected)> OnSelectionIndexChanged { get; }
        IObservable<(string id, bool isSelected)> OnCurrentSelectionIDChanged { get; }
        IObservable<(int index, bool isSelected)> OnCurrentSelectionIndexChanged { get; }
        IObservable<List<string>> OnCurrentSelectedIDListChanged { get; }
        IObservable<List<int>> OnCurrentSelectedIndexListChanged { get; }

        void Add( string id, string title, Sprite sprite, bool isInActive );
        void Remove( string id );
        void Clear();
        void SetActive( string id, bool isActive );
    }
}
