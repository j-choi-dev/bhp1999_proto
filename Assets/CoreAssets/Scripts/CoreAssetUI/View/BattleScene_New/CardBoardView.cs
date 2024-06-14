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
    public class CardBoardView : MonoBehaviour, ICardBoardView
    {
        [SerializeField] private List<CellRootMarker> _rootMarkerList = null;
        [SerializeField] private CardCellView _prefab = null;

        private List<CardCellView> _cells = new List<CardCellView>();
        private  string _currSelectedId = string.Empty;

        private List<ICellBase> _currSelectedCardList = new List<ICellBase>();

        protected  Subject<(string id, bool isSelected)> _onCurrentSelectionIDChanged = new Subject<(string id, bool isSelected)>();
        public IObservable<(string id, bool isSelected)> OnCurrentSelectionIDChanged => _onCurrentSelectionIDChanged;

        protected  Subject<List<string>> _onCurrentSelectedIDListChanged = new Subject<List<string>>();
        public IObservable<IReadOnlyList<string>> OnCurrentSelectedIDListChanged => _onCurrentSelectedIDListChanged;

        private Subject<ICellBase> _onChangeSelectedCardList = new Subject<ICellBase>();
        public IObservable<ICellBase> OnChangeSelectedCardList => _onChangeSelectedCardList;

        private int _maxCount = 0;

        private void Awake()
        {
        }


        public void Add( string id,  Sprite sprite, bool isInActive )
        {
            for( int i = 0; i< _rootMarkerList.Count; i++ )
            {
                if( _rootMarkerList[i].IsAtatched )
                {
                    continue;
                }
                var cell = Instantiate(_prefab, _rootMarkerList[i].transform);

                cell.GameObject.transform.localPosition = _rootMarkerList[i].NormalTransform.localPosition;
                cell.GameObject.transform.localRotation = Quaternion.identity;
                cell.GameObject.transform.localScale = Vector3.one;

                cell.SetID( id );
                cell.SetBackgroundImage( sprite );
                cell.SetSelectWithoutNotify( false );

                cell.OnClick
                    .Subscribe( _ =>
                    {
                        OnCellClicked( cell, _rootMarkerList[i] );
                    } )
                    .AddTo( this );

                _cells.Add( cell );
                _rootMarkerList[i].SetItem( cell );
                break;
            }
        }

        public void Remove( string id )
        {
            var target = _cells.First( arg => arg.ID.Equals( id ) );
            target.GameObject.SetActive( false );
            _cells.Remove( target );
            Destroy( target );
        }

        private void OnCellClicked( ICellBase cell, CellRootMarker marker )
        {
            if( _currSelectedCardList.Count >= _maxCount &&
                _currSelectedCardList.Exists(arg => arg.ID.Equals(cell.ID)) == false )
            {
                return;
            }
            _currSelectedId = cell.ID;
            cell.SetSelectWithoutNotify( !cell.IsSelected );
            if( cell.IsSelected )
            {
                _currSelectedCardList.Add( cell );
            }
            else
            {
                _currSelectedCardList.Remove( cell );
            }
            TransformChangeProcess( cell, marker ).Forget();
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

        public void SetMaxSelectionCount( int val )
        {
            _maxCount = val;
        }

        private async UniTask TransformChangeProcess( ICellBase cell, CellRootMarker rootMarker )
        {
            var destTransform = cell.IsSelected ?
                rootMarker.SelectionTransform :
                rootMarker.NormalTransform;
            while(true)
            {
                var dist = Vector3.Distance( cell.GameObject.transform.position, destTransform.position );
                if( dist < 0.05f )
                {
                    break;
                }
                cell.GameObject.transform.localPosition = Vector3.MoveTowards( cell.GameObject.transform.localPosition, 
                    destTransform.localPosition,
                    200f * Time.deltaTime );
                await UniTask.DelayFrame(1);
            }
            cell.GameObject.transform.localPosition = destTransform.localPosition;
        }
    }
}
