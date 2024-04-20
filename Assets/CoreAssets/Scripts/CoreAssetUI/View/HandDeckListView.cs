using CoreAssetUI.Presenter;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CoreAssetUI.View
{
    public class HandDeckListView : ListView, IHandDeckListView
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

        public override void Add( string id, string title, Sprite sprite, bool isInActive )
        {
            var cell = Instantiate(_prefab, _pivot).GetComponent<ICellBase>();
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

            var obj = cell.GameObject.GetComponent<BattleCard>();

            obj.OnDragStart
                .Subscribe( tupple =>
                {
                    _onDragStarted.OnNext( tupple );
                    Debug.Log( $"OnDragStart : {tupple.id}, {tupple.pos}" );
                } )
                .AddTo( this );

            obj.OnDragEnd
                .Subscribe( tupple =>
                {
                    _onDragEnd.OnNext( tupple );
                    Debug.Log( $"OnDragEnd : {tupple.id}, {tupple.pos}" );
                } )
                .AddTo( this );
        }

        public override void Clear()
        {
            DeselectAll();

            for( int i = 0; i < _cells.Count; ++i )
            {
                Destroy( _cells[i].GameObject );
            }
            _cells.Clear();
        }

        protected void OnCellClicked( ICellBase cell )
        {
            if( string.IsNullOrEmpty( _currSelectedId ) == false
                && _currSelectedId.Equals( cell.ID ) == false )
            {
                DeselectAll();
            }

            cell.IsSelected = !cell.IsSelected;
            _currSelectedId = cell.IsSelected ? cell.ID : string.Empty;
            if( string.IsNullOrEmpty( _currSelectedId ) == false )
            {
                _onSelectionChanged.OnNext( (cell.ID, cell.IsSelected) );
                _onCurrentSelectChanged.OnNext( CurrentSelected() );
            }

            int index = _cells.IndexOf( cell );
            _currSelectedIndex = cell.IsSelected ? cell.Index : -1;
            if( _currSelectedIndex >= 0 )
            {
                _onCurrentSelectIndexChanged.OnNext( CurrentSelectedIndex() );
                _onSelectionIndexChanged.OnNext( (index, cell.IsSelected) );
            }
        }

        private void DeselectAll()
        {
            for( int i = 0; i < _cells.Count; i++ )
            {
                var cell = _cells[i];
                if( cell.IsSelected )
                {
                    cell.SetSelectWithoutNotify( false );
                    _onSelectionChanged.OnNext( (cell.ID, false) );
                }
            }
        }
    }
}
