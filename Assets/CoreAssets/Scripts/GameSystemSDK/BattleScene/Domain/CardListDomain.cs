using GameSystemSDK.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Domain
{
    public class CardListDomain : ICardListDomain
    {
        private List<IBattleCard> _list = new List<IBattleCard>();
        public IReadOnlyList<IBattleCard> AllDeckList => _list;

        private Subject<IReadOnlyList<IBattleCard>> _onCardListChanged = new Subject<IReadOnlyList<IBattleCard>>();
        public IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged => _onCardListChanged;

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

        public IBattleCard GetCard( string id )
        {
            var card = _list.First( arg => arg.ID.Equals( id ) );
            return card;
        }

        public void SetIsDrawn( IReadOnlyList<string> idList )
        {
            for(int i = 0; i < idList.Count; i++ )
            {
                _list.Where( arg => arg.ID.Equals(idList[i]) ).ToList().ForEach( arg => arg.SetDrawn(true) );
            }
            _onCardListChanged.OnNext( _list );
        }
    }
}
