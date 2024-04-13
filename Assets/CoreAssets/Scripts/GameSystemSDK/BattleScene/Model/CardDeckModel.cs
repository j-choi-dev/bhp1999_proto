using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;
using GameSystemSDK.BattleScene.Application;
using Cysharp.Threading.Tasks;
using System.Linq;
using CoreAssetUI.View;

namespace GameSystemSDK.BattleScene.Model
{
    public class CardDeckModel : ICardDeckModel
    {
        private ICardListContext _deckListContext;
        private ICardDeckListImportContext _deckListImportContext;

        public IReadOnlyList<IBattleCard> AllDeckList 
            => _deckListContext.AllDeckList;
        public IObservable<IReadOnlyList<IBattleCard>> OnCardListChanged 
            => _deckListContext.OnCardListChanged;
        public IObservable<IReadOnlyList<IBattleCard>> OnCurrentHandCardListChanged
            => _deckListContext.OnCurrentHandCardListChanged;

        public IReadOnlyList<IBattleCard> CurrentHandDeckList => throw new NotImplementedException();

        public CardDeckModel( ICardListContext cardListContext,
            ICardDeckListImportContext deckListImportContext)
        {
            _deckListContext = cardListContext;
            _deckListImportContext = deckListImportContext;
        }

        public async UniTask Initialize()
        {
            var generateShuffleOperation = await _deckListImportContext.GenerateShuffle();
            var msg = generateShuffleOperation.Select(arg => $"({arg.ID} - {arg.Index})");
            UnityEngine.Debug.Log( $"{string.Join( ", ", msg )}" );
            var operation = _deckListContext.SetCardList( generateShuffleOperation );
            _deckListContext.SetHandCardList();
        }

        public void SetCardList( IReadOnlyList<IBattleCard> list )
        {
            var operation = _deckListContext.SetCardList( list );
        }

        public void AddCard( IBattleCard data )
        {
            var operation = _deckListContext.AddCard( data );
        }

        public void RemoveCard( string id )
        {
            var operation = _deckListContext.RemoveCard(id);
            if( operation.IsSuccess == false)
            {
                UnityEngine.Debug.LogError( operation.ErrorMessage );
                return;
            }
        }

        public void SetHandCardList()
        {
            var operation = _deckListContext.SetHandCardList();
        }
    }
}
