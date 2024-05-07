using CoreAssetUI.Presenter;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class SelectedCardListView : MonoBehaviour, ISelectedCardListView
    {
        [SerializeField] private List<CellRootMarker> _rootMarkerList = null;
        [SerializeField] private List<AnimationLabelObject> _animateLabelObjectList = null;
        [SerializeField] private List<CardEffect> _cardEffectList = null;
        [SerializeField] protected BattleCardCell _prefab;

        protected List<IBattleCardCell> _cells = new List<IBattleCardCell>();
        public IReadOnlyList<ICellBase> Cells => _rootMarkerList.Select( arg => arg.Item ).ToList();

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

        private void Start()
        {
            for(int i = 0; i< _animateLabelObjectList.Count; i++ )
            {
                _animateLabelObjectList[i].ShowLabel( false );
            }
        }

        public void Add( string id, string title, Sprite sprite, bool isInActive )
        {
            for(int i = 0; i< _rootMarkerList.Count; i++ )
            {
                if(_rootMarkerList[i].IsAtatched)
                {
                    continue;
                }
                var cell = Instantiate(_prefab, _rootMarkerList[i].Transform);

                cell.GameObject.transform.localPosition = Vector3.zero;
                cell.GameObject.transform.localRotation = Quaternion.identity;
                cell.GameObject.transform.localScale = Vector3.one;

                cell.SetID( id );
                cell.SetDisplayText( title );
                cell.SetImage( sprite );
                cell.SetSelectWithoutNotify( false );

                cell.OnClick
                    .Subscribe( _ =>
                    {
                        OnCellClicked( cell );
                    } )
                    .AddTo( this );

                _cells.Add( cell );
                _rootMarkerList[i].SetItem( cell );
                _onListCountChanged.OnNext( Cells.Count );
                break;
            }
        }

        public void Clear()
        {
            DeselectAll();

            for( int i = 0; i < _rootMarkerList.Count; ++i )
            {
                _rootMarkerList[i].RemoveItem();
            }
            for( int i = 0; i < _cells.Count; ++i )
            {
                if(_cells[i].GameObject == null)
                {
                    continue;
                }
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
            var rootMarker = _rootMarkerList.Where(arg => arg.IsAtatched)
                .First(arg => arg.Item.ID.Equals(id));
            rootMarker.RemoveItem();
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
            for( int i = 0; i < _cells.Count; i++ )
            {
                _cells[i].SetInteractable( isInteractable );
            }
        }

        public async UniTask SetScoreEffect( int index, int val )
        {
            _animateLabelObjectList[index].SetLabel( $"+{val}" );
            _cells[index].PlayCardAnimation().Forget();
            _animateLabelObjectList[index].Play().Forget();
            _cardEffectList[index].Play().Forget();
        }
    }
}
