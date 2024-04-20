using CoreAssetUI.View;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    public interface IListView
    {
        IReadOnlyList<ICellBase> Cells { get; }

        IObservable<(string id, bool isSelected)> OnSelectionChanged { get; }
        IObservable<(int index, bool isSelected)> OnSelectionIndexChanged { get; }
        IObservable<List<string>> OnCurrentSelectChanged { get; }
        IObservable<List<int>> OnCurrentSelectIndexChanged { get; }

        void Add( string id, string title, Sprite sprite, bool isInActive );
        void Remove( string id );
        void Clear();
        void SetActive( string id, bool isActive );
    }
}
