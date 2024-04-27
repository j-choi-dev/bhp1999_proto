using CoreAssetUI.Presenter;
using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class SelectedCardListView : DoubleSelectListView, ISelectedCardListView
    {
        private Subject<(string id, Vector2 pos)> _onDragStarted = new Subject<(string id, Vector2 pos)>();
        public IObservable<(string id, Vector2 pos)> OnDragStarted => _onDragStarted;

        private Subject<(string id, Vector2 pos)> _onDragEnd = new Subject<(string id, Vector2 pos)>();
        public IObservable<(string id, Vector2 pos)> OnDragEnd => _onDragEnd;
    }
}
