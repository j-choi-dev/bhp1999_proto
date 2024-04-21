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
        private ICardListDomain _domain;

        public IReadOnlyList<IBattleCard> AllList => _domain.AllDeckList;

        public IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged => _domain.OnCardListChanged;

        public IReadOnlyList<IBattleCard> CurrentHandDeckList => _domain.CurrentHandDeckList;

        public IObservable<IReadOnlyList<IBattleCard>> OnCurrentHandCardListChanged => _domain.OnCurrentHandCardListChanged;

        public CardListContext(ICardListDomain listDomain)
        {
            _domain = listDomain;
        }

        public void SetCardList(IReadOnlyList<IBattleCard> list)
            => _domain.SetCardList( list );

        public IResult AddCard( IBattleCard data )
            => _domain.AddCard( data );

        public IResult RemoveCard( string id )
            => _domain.RemoveCard( id );

        public IResult GettHandCardList( IReadOnlyList<IBattleCard> list )
            => _domain.SetCardList( list );

        public IBattleCard GetCard( string id )
            => _domain.GetCard( id );
    }
}