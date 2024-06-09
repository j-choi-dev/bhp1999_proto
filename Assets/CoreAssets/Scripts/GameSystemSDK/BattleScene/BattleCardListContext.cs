using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Card.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using IHandCardListDomain = GameSystemSDK.Card.Domain.IHandCardListDomain;
using ISelectedCardListDomain = GameSystemSDK.Card.Domain.ISelectedCardListDomain;

namespace GameSystemSDK.Card.Application
{
    public class BattleCardListContext : IBattleCardListContext
    {
        private IHandCardListDomain _handCardListDomain;
        private ISelectedCardListDomain _selectedCardListDomain;

        public IObservable<IReadOnlyList<IBattleCard>> OnHandCardListChanged 
            => _handCardListDomain.OnListChanged;

        public IObservable<IReadOnlyList<IBattleCard>> OnSelectedCardListChanged 
            => _selectedCardListDomain.OnListChanged;

        public IObservable<IBattleCard> OnHandCardAdd
            => _handCardListDomain.OnAllCardListAdd;

        public IObservable<IBattleCard> OnHandCardRemoved
            => _handCardListDomain.OnAllCardListRemoved;

        public IObservable<Unit> OnHandCardCleared
            => _handCardListDomain.OnAllCardListCleared;

        public IObservable<IBattleCard> OnSelectedCardAdd
            => _selectedCardListDomain.OnAdd;

        public IObservable<IBattleCard> OnSelectedCardRemoved
            => _selectedCardListDomain.OnRemoved;

        public IObservable<Unit> OnSelectedCardCleared
            => _selectedCardListDomain.OnCleared;

        public IReadOnlyList<IBattleCard> CardList
            => _handCardListDomain.AllList;

        public IReadOnlyList<IBattleCard> CurrenSelectedCard
            => _selectedCardListDomain.List;

        public void AddSelectedCard( IBattleCard item )
        {
            _selectedCardListDomain.Add( item );
        }

        public void AddSelectedCard( IReadOnlyList<IBattleCard> list )
        {
            for( int i = 0; i< list.Count; i++ )
            {
                _selectedCardListDomain.Add( list[i] );
            }
        }

        public void ClearSelectedCardList()
        {
            _selectedCardListDomain.Clear();
        }

        public void RemoveCurrentSelectedCard( IReadOnlyList<string> list )
        {
            for(int i = 0; i< list.Count; i++ )
            {
                _selectedCardListDomain.Remove( list[i] );
            }
        }

        public void RemoveCurrentSelectedCard( string id )
        {
            _selectedCardListDomain.Remove( id );
        }

        public void SetUserCardList( IReadOnlyList<IBattleCard> list )
        {
            _handCardListDomain.SetCardList( list );
        }
    }
}
