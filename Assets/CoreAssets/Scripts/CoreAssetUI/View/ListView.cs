using CoreAssetUI.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public abstract class ListView : MonoBehaviour, IListView
    {
        [SerializeField] protected CellBase _prefab;
        [SerializeField] protected Transform _pivot;

        protected List<ICellBase> _cells = new List<ICellBase>();
        public IReadOnlyList<ICellBase> Cells => _cells;

        protected  string _currSelectedId = string.Empty;
        public string CurrentSelectedID => _currSelectedId;

        protected  Subject<(string id, bool isSelected)> _onSelectionChanged = new Subject<(string id, bool isSelected)>();
        public IObservable<(string id, bool isSelected)> OnSelectionIDChanged => _onSelectionChanged;

        protected  int _currSelectedIndex = -1;
        protected  Subject<(int index, bool isSelected)> _onSelectionIndexChanged = new Subject<(int index, bool isSelected)>();
        public IObservable<(int index, bool isSelected)> OnSelectionIndexChanged => _onSelectionIndexChanged;

        protected  Subject<List<string>> _onCurrentSelectedIDListChanged = new Subject<List<string>>();
        public IObservable<List<string>> OnCurrentSelectedIDListChanged => _onCurrentSelectedIDListChanged;

        protected  Subject<List<int>> _onCurrentSelectIndexChanged = new Subject<List<int>>();
        public IObservable<List<int>> OnCurrentSelectedIndexListChanged => _onCurrentSelectIndexChanged;

        protected Subject<int> _onListCountChanged = new Subject<int>();
        public IObservable<int> OnListCountChanged => _onListCountChanged;


        protected  Subject<(string id, bool isSelected)> _onCurrentSelectionIDChanged = new Subject<(string id, bool isSelected)>();
        public IObservable<(string id, bool isSelected)> OnCurrentSelectionIDChanged => _onCurrentSelectionIDChanged;

        protected  Subject<(int index, bool isSelected)> _onCurrentSelectionIndexChanged = new Subject<(int index, bool isSelected)>();
        public IObservable<(int index, bool isSelected)> OnCurrentSelectionIndexChanged => _onCurrentSelectionIndexChanged;

        public abstract void Add( string id, string title, Sprite sprite, bool isInActive );

        public abstract void Clear();

        public void Remove( string id )
        {
            if( string.IsNullOrEmpty( id ) )
            {
                return;
            }
            var targetCell = _cells
                .Where( x => x.ID == id )
                .FirstOrDefault();

            if( targetCell == null )
            {
                return;
            }
            _cells.Remove( targetCell );
            if( targetCell.IsSelected )
            {
                targetCell.SetSelectWithoutNotify( false );
                _onCurrentSelectedIDListChanged.OnNext( CurrentSelected() );
                _onSelectionChanged.OnNext( (targetCell.ID, false) );
            }

            Destroy( targetCell.GameObject );
        }

        public void SetActive( string id, bool isValue )
        {
            var instance = _cells.First( cell => cell.ID == id );
            instance.IsInteractable = isValue;
        }


        public List<string> CurrentSelected()
        {
            return _cells
                .Where( cell => cell.IsSelected )
                .Select( cell => cell.ID )
                .ToList();
        }

        public List<int> CurrentSelectedIndex()
        {
            return _cells
                .Select( ( cell, index ) => (cell, index) )
                .Where( tuple => tuple.cell.IsSelected == true )
                .Select( tuple => tuple.index )
                .ToList();
        }

        public void SetItemsInteractable( bool isInteractable )
        {
            for(int i = 0; i< _cells.Count; i++)
            {
                _cells[i].SetInteractable( isInteractable );
            }
        }
    }
}
