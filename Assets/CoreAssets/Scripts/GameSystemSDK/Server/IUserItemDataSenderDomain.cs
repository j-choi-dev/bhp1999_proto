using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Server.Domain
{
    public interface IUserItemDataSenderDomain
    {
        UniTask SendSetUserCardDataRequest( byte[] datas );
        UniTask SendUserCardDataRequest();
    }
}
