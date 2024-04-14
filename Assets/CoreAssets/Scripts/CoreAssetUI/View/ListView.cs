using CoreAssetUI.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class ListView : MonoBehaviour, IListView
    {
        [SerializeField] private CellBase _prefab;
        [SerializeField] private Transform _pivot;

        private List<CellBase> _cells = new List<CellBase>();
        public IReadOnlyList<CellBase> Cells => _cells;

        private List<string> _selectedCells = new List<string>();
        public IReadOnlyList<string> SelectedCells => _selectedCells;

        private List<int> _selectedIndices = new List<int>();
        public IReadOnlyList<int> SelectedIndices => _selectedIndices;


        private List<string> _hoveredCells = new List<string>();
        public IReadOnlyList<string> HoveredCells => _hoveredCells;

        private List<int> _hoveredIndices = new List<int>();
        public IReadOnlyList<int> HoveredIndices => _hoveredIndices;

        private Subject<CellStateArg> _onSelectionChanged = new Subject<CellStateArg>();
        public IObservable<CellStateArg> OnSelectionChanged => _onSelectionChanged;

        private Subject<CellStateArg> _onHoveredChanged = new Subject<CellStateArg>();
        public IObservable<CellStateArg> OnHoveredChanged => _onHoveredChanged;

        private Subject<CellStateArg> _onPressed = new Subject<CellStateArg>();
        public IObservable<CellStateArg> OnPressed => _onPressed;

        public void Add( string id, string title, Sprite sprite, bool isInActive )
        {
            var obj = Instantiate(_prefab, _pivot);
            obj.SetID( id );
            obj.SetDisplayText( title );
            obj.SetImage( sprite );
        }

        public void Clear()
        {
            DeselectAll();

            for( int i = 0; i < _cells.Count; ++i )
            {
                Destroy( _cells[i].gameObject );
            }
            _cells.Clear();
        }

        public void Remove( string id )
        {
            var instance = _cells.First( cell => cell.ID == id );
            RemoveImpl( instance );
        }

        public void SetActive( string id, bool isValue )
        {
            var instance = _cells.First( cell => cell.ID == id );
            instance.IsInteractable = isValue;
            instance.enabled = isValue;
        }

        private void RemoveImpl( CellBase cell )
        {
            var index = cell.Index;
            _selectedIndices.Remove( cell.Index );
            _selectedCells.Remove( cell.ID );
            _hoveredIndices.Remove( cell.Index );
            _hoveredCells.Remove( cell.ID );
            _onSelectionChanged.OnNext( new CellStateArg( cell.Index, cell.ID, false ) );

            _cells.Remove( cell );
            Destroy( cell.gameObject );
            RefreshIndices();
        }

        private void RefreshIndices()
        {
            for( int i = 0; i < _cells.Count; ++i )
            {
                _cells[i].Index = i;
            }
        }

        private void DeselectAll()
        {
            for( int i = 0; i < _cells.Count; ++i )
            {
                var cell = _cells[i];
                if( cell.IsSelected )
                {
                    cell.SetSelectWithoutNotify( false );
                    _selectedCells.Remove( cell.ID );
                    _selectedIndices.Remove( cell.Index );
                    _onSelectionChanged.OnNext( new CellStateArg( i, cell.ID, false ) );
                }
                if( cell.IsHovered )
                {
                    cell.SetHoveredWithoutNotify( false );
                    _hoveredIndices.Remove( cell.Index );
                    _hoveredCells.Remove( cell.ID );
                    _onHoveredChanged.OnNext( new CellStateArg( i, cell.ID, false ) );
                }
            }
            _selectedCells.Clear();
            _selectedIndices.Clear();
        }
    }
}
