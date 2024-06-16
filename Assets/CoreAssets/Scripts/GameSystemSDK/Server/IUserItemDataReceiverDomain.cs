using System;
using System.Collections.Generic;

namespace GameSystemSDK.Server.Domain
{
    public interface IUserItemDataReceiverDomain
    {
        IObservable<IReadOnlyList<ICardBase>> OnReceivedBattleCardList { get; }
    }
}
