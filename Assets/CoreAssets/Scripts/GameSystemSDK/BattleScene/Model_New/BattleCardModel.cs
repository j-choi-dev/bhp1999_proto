using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Card.Application;
using GameSystemSDK.Server.Apllication;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace GameSystemSDK.BattleScene.Model
{
    public class BattleCardModel : IBattleCardModel
    {
        private IBattleCardListContext _battleCardListContext;
        private IUserItemDataNetworkContext _networkContext;
        private IBattleCardFactoryContext _battleCardFactoryContext;
        private InGameConstValue _inGameConstValue;

        public IReadOnlyList<IBattleCard> CurrentCardList 
            => _battleCardListContext.CardList;

        public IReadOnlyList<IBattleCard> CurrentSelectedList 
            => _battleCardListContext.CurrenSelectedCard;

        public IObservable<IReadOnlyList<IBattleCard>> OnHandCardListChanged 
            => _battleCardListContext.OnHandCardListChanged;

        public IObservable<IBattleCard> OnPlayingCardAdd 
            => _battleCardListContext.OnPlayingCardAdd;

        public IObservable<IBattleCard> OnPlayingCardRemoved 
            => _battleCardListContext.OnHandPlayingRemoved;

        public IObservable<Unit> OnHandCardCleared 
            => _battleCardListContext.OnPlayingCardCleared;

        public IObservable<IReadOnlyList<IBattleCard>> OnSelectionCardListCahnged 
            => _battleCardListContext.OnSelectedCardListChanged;

        public IObservable<IBattleCard> OnSelectedCardAdd
            => _battleCardListContext.OnSelectedCardAdd;

        public IObservable<IBattleCard> OnSelectedCardRemoved 
            => _battleCardListContext.OnSelectedCardRemoved;

        public IObservable<Unit> OnSelectedCardCleared 
            => _battleCardListContext.OnSelectedCardCleared;

        public int MaxSelectionCount => _inGameConstValue.MaxSelectCardCount;

        public BattleCardModel( IBattleCardListContext battleCardListContext,
            IUserItemDataNetworkContext networkContext,
            IBattleCardFactoryContext battleCardFactoryContext )
        {
            _battleCardListContext = battleCardListContext;
            _networkContext = networkContext;
            _battleCardFactoryContext = battleCardFactoryContext;
            _inGameConstValue= new InGameConstValue();
        }

        public async UniTask Initialize()
        {
            var cardDatas = await _networkContext.UserCardDataRequest();
            var cardList = new List<IBattleCard>();
            for(int i = 0; i< cardDatas.Value.Count; i++ )
            {
                var item = cardDatas.Value[i];
                var playingCard = _battleCardFactoryContext.ConvertToPlayingCard(item.ID, item.Suit, item.Chip, item.Rank, item.EnchantSlot1, item.EnchantSlot2, item.EnchantSlot3);
                var battleCard = _battleCardFactoryContext.ConvertToBattleCard(playingCard, i);
                cardList.Add( battleCard );
            }

            // 소지한 카드 정보를 리스트 데이터 클래스에 등록
            _battleCardListContext.SetUserCardList( cardList );
            _battleCardListContext.GetPlayingCardList();
        }

        public void AddSelectedCard( string id )
        {
            var all = string.Join("\n", _battleCardListContext.CardList.Select(arg => arg.PlayingCardInfo.ID));
            //UnityEngine.Debug.Log( $"{id} / {_battleCardListContext.CardList.Count}\n{all}" );
            //for(int i = 0; i<_battleCardListContext.CardList.Count; i++ )
            //{
            //    var currCard = _battleCardListContext.CardList[i];
            //    if( currCard.PlayingCardInfo.ID.ToString().Equals( id ) )
            //    {
            //        _battleCardListContext.AddSelectedCard( currCard );
            //        UnityEngine.Debug.Log( $"<color=yellow>{id} == {currCard.PlayingCardInfo.ID} == {currCard.PlayingCardInfo.ID.ToString().Equals( id )}</color>" );
            //    }
            //    else
            //    {
                        
            //    }
            //    {
            //        UnityEngine.Debug.Log( $"{id}({Convert.ToByte( id )}) == {currCard.PlayingCardInfo.ID}({Convert.ToByte(currCard.PlayingCardInfo.ID)}) == {currCard.PlayingCardInfo.ID.Equals( id )}" );
            //    }
            //}
            var targetCard = _battleCardListContext.CardList.First(arg => arg.PlayingCardInfo.ID.ToString().Equals(id));
            _battleCardListContext.AddSelectedCard( targetCard );
        }

        public void RemoveSelectedCard( string id )
        {
            _battleCardListContext.RemoveCurrentSelectedCard( id );
        }

        public void ClearSelectedCardList()
        {
            _battleCardListContext.ClearSelectedCardList();
        }
    }
}
