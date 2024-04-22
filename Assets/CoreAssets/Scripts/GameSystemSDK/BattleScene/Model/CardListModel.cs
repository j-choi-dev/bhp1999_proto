using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;
using GameSystemSDK.BattleScene.Application;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameSystemSDK.BattleScene.Model
{
    public class CardListModel : ICardListModel
    {
        private ICardListContext _cardListContext;
        private ISelectedCardListContext _selectedListContext;
        private IHandCardListContext _handCardListContext;
        private ICardDeckListImportContext _deckListImportContext;

        public IReadOnlyList<IBattleCard> AllDeckList 
            => _cardListContext.AllList;
        public IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged 
            => _cardListContext.OnCardListChanged;

        public IReadOnlyList<IBattleCard> CurrentHandDeckList 
            => _handCardListContext.List;
        public IObservable<IReadOnlyList<IBattleCard>> OnCurrentHandCardListChanged
            => _handCardListContext.OnListChanged;
        public IObservable<IBattleCard> OnCurrentHandCardListAdd => _handCardListContext.OnAdd;
        public IObservable<IBattleCard> OnCurrentHandCardListRemoved => _handCardListContext.OnRemove;

        public IObservable<IReadOnlyList<IBattleCard>> OnCurrentSelectedCardListChanged 
            => _selectedListContext.OnListChanged;
        public IObservable<IBattleCard> OnCurrentSelectedCardAdd 
            => _selectedListContext.OnAdd;
        public IObservable<IBattleCard> OnCurrentSelectedCardRemoved 
            => _selectedListContext.OnRemove;

        public CardListModel( ICardListContext cardListContext,
            ISelectedCardListContext selectedListContext,
            IHandCardListContext handCardListContext,
            ICardDeckListImportContext deckListImportContext )
        {
            _cardListContext = cardListContext;
            _selectedListContext = selectedListContext;
            _handCardListContext = handCardListContext;
            _deckListImportContext = deckListImportContext;
        }

        public async UniTask Initialize()
        {
            var mock = UnityEngine.Random.Range(0, 9);
            var generateShuffleOperation = await _deckListImportContext.GenerateShuffle();
            _cardListContext.SetCardList( generateShuffleOperation );
            _handCardListContext.UpdateList( _cardListContext.AllList );
        }

        public void UpdateCardList()
        {
            _handCardListContext.UpdateList( _cardListContext.AllList );
        }

        public void AddCard( IBattleCard data )
        {
            _cardListContext.AddCard( data );
        }

        public void RemoveCard( string id )
        {
            var operation = _cardListContext.RemoveCard(id);
            if( operation.IsSuccess == false)
            {
                UnityEngine.Debug.LogError( operation.ErrorMessage );
                return;
            }
        }

        public void UpdateCardDatas()
        {
            _handCardListContext.UpdateList( _cardListContext.AllList );
        }

        public void MoveToSelectedList( string id )
        {
            if( _selectedListContext.IsAddAble == false )
            {
                return;
            }
            var card = _cardListContext.GetCard( id );
            _selectedListContext.Add(card);
            _handCardListContext.SetIsSelected( card.ID, true );
        }

        public void ReturnToHandList( string id )
        {
            Debug.Log( $"<color=yellow>cardDeckModel.ReturnToHandList ... {id}</color>" );
            var card = _cardListContext.GetCard( id );
            _handCardListContext.SetIsSelected( card.ID, false );
            _selectedListContext.Remove( card.ID );
        }
    }
}
