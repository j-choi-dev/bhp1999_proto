using GameSystemSDK.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace GameSystemSDK.BattleScene.Domain
{
    public class CardListDomain : ICardListDomain
    {
        private int _totalHandDeckCount = 0; // TODO Magic Number @Choi 24.04.13
        private List<IBattleCard> _list = new List<IBattleCard>();
        public IReadOnlyList<IBattleCard> AllDeckList => _list;

        private List<IBattleCard> _currHandList = new List<IBattleCard>();
        public IReadOnlyList<IBattleCard> CurrentHandDeckList => _currHandList;

        private Subject<IReadOnlyList<IBattleCard>> _onCardListChanged = new Subject<IReadOnlyList<IBattleCard>>();
        public IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged => _onCardListChanged;

        private Subject<IReadOnlyList<IBattleCard>> _onCurrentHandCardListChanged = new Subject<IReadOnlyList<IBattleCard>>();
        public IObservable<IReadOnlyList<IBattleCard>> OnCurrentHandCardListChanged => _onCurrentHandCardListChanged;

        public CardListDomain()
        {
            _totalHandDeckCount = 8;
        }

        public IResult SetCardList( IReadOnlyList<IBattleCard> list )
        {
            _list.AddRange( list );
            _onCardListChanged.OnNext( _list );
            return Result.Success();
        }

        public IResult AddCard( IBattleCard data )
        {
            _list.Add( data );
            _onCardListChanged.OnNext( _list );
            return Result.Success();
        }

        public IResult RemoveCard( string id )
        {
            var item = _list.First(arg => arg.ID.Equals(id));
            if( item == null )
            {
                return Result.Fail( $"CardDeckModel.RemoveCard :  {id} Not Exist" );
            }
            _list.Remove( item );
            _onCardListChanged.OnNext( _list );
            return Result.Success();
        }

        public IResult SetHandCardList()
        {
            var retVal = new List<IBattleCard>();
            retVal.AddRange( _currHandList );
            for(int i = 0; i < _totalHandDeckCount - _currHandList.Count; i++ )
            {
                var data = _list.Where(arg => arg.IsInHand == false && arg.IsDrawn == false).ToList().First();
                retVal.Add( data );
                _list.Find( arg => arg.ID.Equals( data.ID ) ).SetInHand( true );
            }
            _currHandList.Clear();
            _currHandList.AddRange( retVal );
            _onCurrentHandCardListChanged.OnNext( _currHandList );
            return Result.Success();
        }
    }
}
