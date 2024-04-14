using CoreAssetUI.View;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.Presenter
{
    public interface IListView
    {
        IReadOnlyList<CellBase> Cells { get; }
        IReadOnlyList<string> SelectedCells { get; }
        IReadOnlyList<int> SelectedIndices { get; }
        IReadOnlyList<string> HoveredCells { get; }
        IReadOnlyList<int> HoveredIndices { get; }
        IObservable<CellStateArg> OnSelectionChanged { get; }
        IObservable<CellStateArg> OnHoveredChanged { get; }
        IObservable<CellStateArg> OnPressed { get; }
        void Add( string id, string title, Sprite sprite, bool isInActive );
        void Remove( string id );
        void Clear();
        void SetActive( string id, bool isActive );
    }
}
