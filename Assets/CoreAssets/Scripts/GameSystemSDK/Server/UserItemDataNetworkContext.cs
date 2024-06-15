using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using GameSystemSDK.Server.Domain;
using GameSystemSDK.Server.Infrastructure;
using System.Collections.Generic;
using UniRx;

namespace GameSystemSDK.Server.Apllication
{
    public class UserItemDataNetworkContext : IUserItemDataNetworkContext
    {
        private IUserItemDataSenderDomain _sender;
        private IUserItemDataReceiverDomain _receiver;

        public UserItemDataNetworkContext( IUserItemDataSenderDomain sender,
            IUserItemDataReceiverDomain receiver )
        {
            _sender = sender;
            _receiver = receiver;
        }

        public UniTask SendSetUserCardDataRequest( IReadOnlyList<IBattleCard> list )
        {
            throw new System.NotImplementedException();
        }

        public async UniTask<IResult<IReadOnlyList<ICardBase>>> UserCardDataRequest()
        {
            await _sender.SendUserCardDataRequest();

            var mock = _receiver as UserItemDataReceiverMock;
            if( mock != null )
            {
                var responseTask = _receiver.OnReceivedBattleCardList.First().ToUniTask(true);
                await mock.SetMockData();
                var response = await responseTask;
                if( response != null )
                {
                    return Result.Success( response );
                }
            }

            return Result.Fail<IReadOnlyList<ICardBase>>( "Failed to receive data" );
        }
    }
}
