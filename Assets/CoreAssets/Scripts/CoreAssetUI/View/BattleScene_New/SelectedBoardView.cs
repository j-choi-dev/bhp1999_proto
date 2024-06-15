using CoreAssetUI.Presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class SelectedBoardView : MonoBehaviour, ISelectedBoardView
    {
        [SerializeField] private Transform _pivot = null;
        [SerializeField] private SelectedCardCell _prefab = null;

        private List<ISelectedCardCell> _cells = new List<ISelectedCardCell>();
        private  string _currSelectedId = string.Empty;

        private List<ISelectedCardCell> _currSelectedCardList = new List<ISelectedCardCell>();

        protected  Subject<(string id, bool isSelected)> _onCurrentSelectionIDChanged = new Subject<(string id, bool isSelected)>();
        public IObservable<(string id, bool isSelected)> OnCurrentSelectionIDChanged => _onCurrentSelectionIDChanged;

        protected  Subject<List<string>> _onCurrentSelectedIDListChanged = new Subject<List<string>>();
        public IObservable<IReadOnlyList<string>> OnCurrentSelectedIDListChanged => _onCurrentSelectedIDListChanged;

        private Subject<ICellBase> _onChangeSelectedCardList = new Subject<ICellBase>();
        public IObservable<ICellBase> OnChangeSelectedCardList => _onChangeSelectedCardList;

        private void Awake()
        {
        }


        public void Add( string id, string title, Sprite sprite, bool isInActive )
        {
        }

        public void Remove( string id )
        {
        }

        public void Clear()
        {
        }
    }
}
