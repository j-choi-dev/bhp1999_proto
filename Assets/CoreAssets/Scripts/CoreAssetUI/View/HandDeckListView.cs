using CoreAssetUI.Presenter;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CoreAssetUI.View
{
    public class HandDeckListView : DoubleSelectListView, IHandDeckListView
    {
        [SerializeField] Image _image;
        private Subject<(string id, Vector2 pos)> _onDragStarted = new Subject<(string id, Vector2 pos)>();
        public IObservable<(string id, Vector2 pos)> OnDragStarted => _onDragStarted;

        private Subject<(string id, Vector2 pos)> _onDragEnd = new Subject<(string id, Vector2 pos)>();
        public IObservable<(string id, Vector2 pos)> OnDragEnd => _onDragEnd;

        private void Awake()
        {
            _image.gameObject.SetActive( false );
        }
    }
}
