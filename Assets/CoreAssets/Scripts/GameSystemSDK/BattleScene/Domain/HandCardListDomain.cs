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
        public IReadOnlyList<IBattleCard> List => _list.Where(arg => arg.IsSelected == false).ToList();

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
            _onCardListChanged.OnNext( List );
        }

        public void Clear()
        {
            _list.Clear();
            _onCardListChanged.OnNext( _list );
        }

        public void SetIsSelected( string id, bool isSelection )
        {
            var index = _list.FindIndex(arg => arg.PlayingCardInfo.ID.ToString().Equals( id ));
            _list[index].SetIsSelected( isSelection );
            _onCardListChanged.OnNext( List );
        }

        public void UpdateList( IReadOnlyList<IBattleCard> list )
        {
            var retVal = new List<IBattleCard>();
            var notDrawnList = _list.Where( arg => arg.IsInPlayDeck == true && arg.IsDrawn == false ).ToList();
            retVal.AddRange( notDrawnList );
            for( int i = 0; i < _totalHandDeckCount - notDrawnList.Count; i++ )
            {
                var valiableList = list.Where(arg => arg.IsInPlayDeck == false && arg.IsDrawn == false).ToList();
                var data = valiableList.First();
                retVal.Add( data );
                list.Where( arg => arg.PlayingCardInfo.ID.ToString().Equals( data.PlayingCardInfo.ID.ToString() ) )
                    .ToList()
                    .ForEach( arg => arg.SetInHand( true ) );
                _onAdd.OnNext( data );
            }
            _list.Clear();
            _list.AddRange( retVal );
            _onCardListChanged.OnNext( List );
        }

        public IBattleCard GetCard( string id )
        {
            var card = _list.First( arg => arg.PlayingCardInfo.ID.ToString().Equals( id ) );
            return card;
        }

        public void RemoveCard( IBattleCard data )
        {
            _list.Remove( data );
            _onCardListChanged.OnNext( List );

        }
    }
}
