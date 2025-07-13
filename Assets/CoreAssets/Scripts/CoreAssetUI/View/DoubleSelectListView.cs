using CoreAssetUI.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    /// <summary>
    /// 이중 선택이 가능한 Cell에 대한 List View
    /// @Auth Choi
    /// </summary>
    // TODO ダブルタップ専用は別度のIF作って分離し、そっちを同時継承させるのが良いかも @Choi 24.05.05
    public abstract class DoubleSelectListView : MonoBehaviour, IListView
    {
        [SerializeField] protected CellBase _prefab;
        [SerializeField] protected Transform _pivot;

        protected List<IDoubleTapCell> _cells = new List<IDoubleTapCell>();
        public IReadOnlyList<ICellBase> Cells => _cells.Select( arg => arg ).ToList();

        protected  string _currSelectedId = string.Empty;
        public string CurrentSelectedID => _currSelectedId;

        protected  Subject<(string id, bool isSelected)> _onSelectionIDChanged = new Subject<(string id, bool isSelected)>();
        public IObservable<(string id, bool isSelected)> OnSelectionIDChanged => _onSelectionIDChanged;

        protected  int _currSelectedIndex = int.MinValue;
        protected  Subject<(int index, bool isSelected)> _onSelectionIndexChanged = new Subject<(int index, bool isSelected)>();
        public IObservable<(int index, bool isSelected)> OnSelectionIndexChanged => _onSelectionIndexChanged;

        protected  Subject<(string id, bool isSelected)> _onCurrentSelectionIDChanged = new Subject<(string id, bool isSelected)>();
        public IObservable<(string id, bool isSelected)> OnCurrentSelectionIDChanged => _onCurrentSelectionIDChanged;

        protected  Subject<(int index, bool isSelected)> _onCurrentSelectionIndexChanged = new Subject<(int index, bool isSelected)>();
        public IObservable<(int index, bool isSelected)> OnCurrentSelectionIndexChanged => _onCurrentSelectionIndexChanged;

        protected  Subject<List<string>> _onCurrentSelectedIDListChanged = new Subject<List<string>>();
        public IObservable<List<string>> OnCurrentSelectedIDListChanged => _onCurrentSelectedIDListChanged;

        protected  Subject<List<int>> _onCurrentSelectedIndexListChanged = new Subject<List<int>>();
        public IObservable<List<int>> OnCurrentSelectedIndexListChanged => _onCurrentSelectedIndexListChanged;

        protected Subject<int> _onListCountChanged = new Subject<int>();
        public IObservable<int> OnListCountChanged => _onListCountChanged;

        private void Awake()
        {
            _onListCountChanged.OnNext( Cells.Count ); 
        }

        public void Add( string id, string title, Sprite sprite, bool isInActive )
        {
            var cell = Instantiate(_prefab, _pivot).GetComponent<IDoubleTapCell>();
            cell.SetID( id );
            cell.SetDisplayText( title );
            cell.SetImage( sprite );
            cell.SetSelectWithoutNotify( false );
            _cells.Add( cell );

            cell.OnClick
                .Subscribe( _ =>
                {
                    OnCellClicked( cell );
                } )
                .AddTo( this );

            _onListCountChanged.OnNext( Cells.Count );
        }

        public void Clear()
        {
            DeselectAll();

            for( int i = 0; i < _cells.Count; ++i )
            {
                Destroy( _cells[i].GameObject );
            }
            _cells.Clear();
            _onListCountChanged.OnNext( Cells.Count );
        }

        protected void OnCellClicked( IDoubleTapCell cell )
        {
            if( string.IsNullOrEmpty( _currSelectedId ) == false
                && _currSelectedId.Equals( cell.ID ) == false )
            {
                DeselectAll();
                _currSelectedIndex = int.MinValue;
            }

            if( cell.IsSelected && cell.IsDoubleSelected  == false )
            {
                cell.IsDoubleSelected = true;
                cell.SetDoubleSelectWithoutNotify( cell.IsDoubleSelected );

                _onSelectionIDChanged.OnNext( (cell.ID, cell.IsDoubleSelected) );
                _onSelectionIndexChanged.OnNext( (cell.Index, cell.IsDoubleSelected) );
                cell.IsSelected = false;
                cell.SetSelectWithoutNotify( false );
                _onCurrentSelectionIDChanged.OnNext( (cell.ID, cell.IsSelected) );
                _onCurrentSelectionIndexChanged.OnNext( (cell.Index, cell.IsSelected) );
            }
            else if( cell.IsSelected == false )
            {
                cell.IsSelected = true;
                cell.SetSelectWithoutNotify( cell.IsSelected );
                _onCurrentSelectionIDChanged.OnNext( (cell.ID, cell.IsSelected) );
                _onCurrentSelectionIndexChanged.OnNext( (cell.Index, cell.IsSelected) );
            }
            else
            {
                cell.SetSelectWithoutNotify( false );
                cell.SetDoubleSelectWithoutNotify( false );
                _onCurrentSelectionIDChanged.OnNext( (cell.ID, false) );
                _onCurrentSelectionIndexChanged.OnNext( (cell.Index, false) );
            }
            _currSelectedId = cell.IsSelected ? cell.ID : string.Empty;
            _currSelectedIndex = cell.IsSelected ? cell.Index : int.MinValue;

            _onCurrentSelectedIDListChanged.OnNext( GetCurrentSelectedIDList() );
            _onCurrentSelectedIndexListChanged.OnNext( GetCurrentSelectedIndexList() );
        }

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
                targetCell.SetDoubleSelectWithoutNotify( false );

                _onCurrentSelectedIDListChanged.OnNext( GetCurrentSelectedIDList() );
                _onCurrentSelectedIndexListChanged.OnNext( GetCurrentSelectedIndexList() );

                _onSelectionIDChanged.OnNext( (targetCell.ID, false) );
            }

            _onListCountChanged.OnNext( Cells.Count );
            if( _currSelectedId.Equals( targetCell.ID ) )
            {
                _currSelectedId = string.Empty;
            }
            if( _currSelectedIndex.Equals( targetCell.Index ) )
            {
                _currSelectedId = string.Empty;
            }
            _onSelectionIDChanged.OnNext( (_currSelectedId, false) );
            Destroy( targetCell.GameObject );
        }

        public void SetActive( string id, bool isValue )
        {
            var instance = _cells.First( cell => cell.ID == id );
            instance.IsInteractable = isValue;
        }


        public List<string> GetCurrentSelectedIDList()
        {
            return _cells
                .Where( cell => cell.IsSelected )
                .Select( cell => cell.ID )
                .ToList();
        }

        public List<int> GetCurrentSelectedIndexList()
        {
            return _cells
                .Select( ( cell, index ) => (cell, index) )
                .Where( tuple => tuple.cell.IsSelected == true )
                .Select( tuple => tuple.index )
                .ToList();
        }

        private void DeselectAll()
        {
            for( int i = 0; i < _cells.Count; i++ )
            {
                var cell = _cells[i];
                if( cell.IsSelected )
                {
                    cell.SetSelectWithoutNotify( false );
                    cell.SetDoubleSelectWithoutNotify( false );

                    _onCurrentSelectionIDChanged.OnNext( (cell.ID, false) );
                    _onCurrentSelectionIndexChanged.OnNext( (cell.Index, false) );

                    _onSelectionIDChanged.OnNext( (cell.ID, false) );
                    _onSelectionIndexChanged.OnNext( (cell.Index, false) );
                }
            }

            _onCurrentSelectedIDListChanged.OnNext( GetCurrentSelectedIDList() );
            _onCurrentSelectedIndexListChanged.OnNext( GetCurrentSelectedIndexList() );
        }

        public void SetItemsInteractable( bool isInteractable )
        {
            for(int i = 0; i < _cells.Count; i++)
            {
                _cells[i].SetInteractable( isInteractable );
            }
        }
    }
}
