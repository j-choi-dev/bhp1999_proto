using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class CardBoardView : MonoBehaviour
    {
        [SerializeField] private List<CellRootMarker> _rootMarkerList = null;
        [SerializeField] private CardCellView _prefab = null;

        private List<CardCellView> _cells = new List<CardCellView>();
        private  string _currSelectedId = string.Empty;

        private List<ICellBase> _currSelectedCardList = new List<ICellBase>();

        protected  Subject<(string id, bool isSelected)> _onCurrentSelectionIDChanged = new Subject<(string id, bool isSelected)>();
        public IObservable<(string id, bool isSelected)> OnCurrentSelectionIDChanged => _onCurrentSelectionIDChanged;

        protected  Subject<List<string>> _onCurrentSelectedIDListChanged = new Subject<List<string>>();
        public IObservable<List<string>> OnCurrentSelectedIDListChanged => _onCurrentSelectedIDListChanged;

        private Subject<ICellBase> _onChangeSelectedCardList = new Subject<ICellBase>();
        public IObservable<ICellBase> OnChangeSelectedCardList => _onChangeSelectedCardList;

        private void Awake()
        {
        }


        public void Add( string id, string title, Sprite sprite, bool isInActive )
        {
            for( int i = 0; i< _rootMarkerList.Count; i++ )
            {
                if( _rootMarkerList[i].IsAtatched )
                {
                    continue;
                }
                var cell = Instantiate(_prefab, _rootMarkerList[i].SelectionTransform);

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
                break;
            }
        }

        private void OnCellClicked( ICellBase cell )
        {
            if( string.IsNullOrEmpty( _currSelectedId ) == false
                && _currSelectedId.Equals( cell.ID ) == false )
            {
            }
            
            cell.IsSelected = !cell.IsSelected;
            cell.SetSelectWithoutNotify( !cell.IsSelected );
            _currSelectedCardList.Remove( cell );
            _onCurrentSelectionIDChanged.OnNext( (cell.ID, cell.IsSelected) );

            _onCurrentSelectedIDListChanged.OnNext( GetCurrentSelectedIDList() );
        }

        private List<string> GetCurrentSelectedIDList()
        {
            return _cells
                .Where( cell => cell.IsSelected )
                .Select( cell => cell.ID )
                .ToList();
        }
    }
}
