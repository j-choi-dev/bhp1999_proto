using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Server.Domain;
using System.Collections.Generic;
using UniRx;
using IHandCardListDomain = GameSystemSDK.Card.Domain.IHandCardListDomain;

namespace GameSystemSDK.Server.Apllication
{
    public class UserItemDataNetworkContext : IUserItemDataNetworkContext
    {
        private IUserItemDataSenderDomain _sender;
        private IUserItemDataReceiverDomain _receiver;
        private IHandCardListDomain _cardListDomain;

        public UserItemDataNetworkContext( IUserItemDataSenderDomain sender )
        {
            _sender = sender;
        }
        public UniTask SendSetUserCardDataRequest( IReadOnlyList<IBattleCard> list )
        {
            throw new System.NotImplementedException();
        }

        public async UniTask<IReadOnlyList<ICardBase>> UserCardDataRequest()
        {
            await _sender.SendUserCardDataRequest();
            var response = await _receiver.OnReceivedBattleCardList.First();
            return new List<ICardBase>();
        }
    }
}
