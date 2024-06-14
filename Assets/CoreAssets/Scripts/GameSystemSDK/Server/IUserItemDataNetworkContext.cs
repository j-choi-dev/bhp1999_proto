using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using GameSystemSDK.Server.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Server.Apllication
{
    public interface IUserItemDataNetworkContext
    {
        UniTask SendSetUserCardDataRequest(IReadOnlyList<IBattleCard> list );
        UniTask<IResult<IReadOnlyList<ICardBase>>> UserCardDataRequest();
    }
}
