using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Application
{
    public class CardListContext : ICardListContext
    {
        private ICardListDomain _listDomain;

        public IReadOnlyList<IBattleCard> AllDeckList => _listDomain.AllDeckList;

        public IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged => _listDomain.OnCardListChanged;

        public IReadOnlyList<IBattleCard> CurrentHandDeckList => _listDomain.CurrentHandDeckList;

        public IObservable<IReadOnlyList<IBattleCard>> OnCurrentHandCardListChanged => _listDomain.OnCurrentHandCardListChanged;

        public CardListContext(ICardListDomain listDomain)
        {
            _listDomain = listDomain;
        }

        public IResult AddCard( IBattleCard data )
            => _listDomain.AddCard( data );

        public IResult RemoveCard( string id )
            => _listDomain.RemoveCard( id );

        public IResult SetCardList( IReadOnlyList<IBattleCard> list )
            => _listDomain.SetCardList( list );

        public IResult GettHandCardList( IReadOnlyList<IBattleCard> list )
            => _listDomain.SetCardList( list );

        public IResult SetHandCardList()
            => _listDomain.SetHandCardList();
    }
}
