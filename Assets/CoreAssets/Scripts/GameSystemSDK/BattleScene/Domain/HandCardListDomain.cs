using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace GameSystemSDK.BattleScene.Domain
{
    public class HandCardListDomain : IHandCardListDomain
    {
        private int _totalHandDeckCount = 0; // TODO Magic Number @Choi 24.04.13

        private List<IBattleCard> _list = new List<IBattleCard>();
        public IReadOnlyList<IBattleCard> List => _list;

        private Subject<IReadOnlyList<IBattleCard>> _onCardListChanged = new Subject<IReadOnlyList<IBattleCard>>();
        public IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged => _onCardListChanged;

        private Subject<IBattleCard> _onAdd = new Subject<IBattleCard>();
        public IObservable<IBattleCard> OnAdd => _onAdd;

        private Subject<IBattleCard> _onRemove = new Subject<IBattleCard>();
        public IObservable<IBattleCard> OnRemove => _onRemove;

        public HandCardListDomain()
        {
            _totalHandDeckCount = 8;
        }

        public void AddCard( IBattleCard data )
        {
            _list.Add( data );
            _onAdd.OnNext( data );
            _onCardListChanged.OnNext( _list );
        }

        public void Clear()
        {
            _list.Clear();
            _onCardListChanged.OnNext( _list );
        }

        public void RemoveCard( string id )
        {
            var card = _list.Find( arg => arg.ID.Equals( id ) );
            _list.Remove( card );
            _onRemove.OnNext( card );
            _onCardListChanged.OnNext( _list );
        }

        public void UpdateList( IReadOnlyList<IBattleCard> list )
        {
            var retVal = new List<IBattleCard>();
            retVal.AddRange( _list );
            for( int i = 0; i < _totalHandDeckCount - _list.Count; i++ )
            {
                var data = list.Where(arg => arg.IsInHand == false && arg.IsDrawn == false).ToList().First();
                retVal.Add( data );
                list.ToList().Find( arg => arg.ID.Equals( data.ID ) ).SetInHand( true );
                _onAdd.OnNext( data );
            }
            _list.Clear();
            _list.AddRange( retVal );
            _onCardListChanged.OnNext( _list );
        }

        public IBattleCard GetCard( string id )
        {
            var card = _list.First( arg => arg.ID.Equals( id ) );
            return card;
        }
    }
}
