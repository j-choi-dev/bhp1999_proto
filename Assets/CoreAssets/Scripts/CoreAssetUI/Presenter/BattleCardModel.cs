using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Card.Application;
using GameSystemSDK.Server.Apllication;
using GameSystemSDK.Server.Domain;
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

        public IReadOnlyList<IBattleCard> CurrentCardList 
            => _battleCardListContext.CardList;

        public IReadOnlyList<IBattleCard> CurrentSelectedList 
            => _battleCardListContext.CurrenSelectedCard;

        public IObservable<IReadOnlyList<IBattleCard>> OnHandCardListChanged 
            => _battleCardListContext.OnHandCardListChanged;

        public IObservable<IBattleCard> OnHandCardAdd 
            => _battleCardListContext.OnHandCardAdd;

        public IObservable<IBattleCard> OnHandCardRemoved 
            => _battleCardListContext.OnHandCardRemoved;

        public IObservable<Unit> OnHandCardCleared 
            => _battleCardListContext.OnHandCardCleared;

        public IObservable<IReadOnlyList<IBattleCard>> OnSelectionCardListCahnged 
            => _battleCardListContext.OnSelectedCardListChanged;

        public IObservable<IBattleCard> OnSelectedCardAdd
            => _battleCardListContext.OnSelectedCardAdd;

        public IObservable<IBattleCard> OnSelectedCardRemoved 
            => _battleCardListContext.OnSelectedCardRemoved;

        public IObservable<Unit> OnSelectedCardCleared 
            => _battleCardListContext.OnSelectedCardCleared;

        public BattleCardModel( IBattleCardListContext battleCardListContext,
            IUserItemDataNetworkContext networkContext,
            IBattleCardFactoryContext battleCardFactoryContext )
        {
            _battleCardListContext = battleCardListContext;
            _networkContext = networkContext;
            _battleCardFactoryContext = battleCardFactoryContext;
        }

        public async UniTask Initialize()
        {
            // 서버에서 유저가 소지한 카드 리스트 받아옴.
            var cardDatas = await _networkContext.UserCardDataRequest();
            var mock = new List<ICardBase>();

            // 유저가 소지한 카드 리스트를, 카드 정보로 변환
            // TODO : 별도 Context 필요? -> 경우에 따라서는 팩토리 필요. @Choi 24.06.06
            var cardList = new List<IBattleCard>();
            for(int i = 0; i<cardDatas.Count; i++ )
            {
                var item = cardDatas[i];
                var playingCard = _battleCardFactoryContext.ConvertToBattleCard(item.ID, item.Type, item.Value, item.EnchantSlot1, item.EnchantSlot2, item.EnchantSlot3);
                cardList[i].SetPlayingCardInfo( playingCard );
            }

            // 소지한 카드 정보를 리스트 데이터 클래스에 등록
            _battleCardListContext.SetUserCardList( cardList );
        }

        public void AddSelectedCard( string id )
        {
            var targetCard = _battleCardListContext.CardList.First(arg => arg.PlayingCardInfo.ID.Equals(id));
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
