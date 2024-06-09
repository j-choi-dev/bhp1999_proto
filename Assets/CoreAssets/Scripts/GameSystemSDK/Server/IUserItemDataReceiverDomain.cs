using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Server.Domain
{
    public interface IUserItemDataReceiverDomain
    {
        IObservable<byte[]> OnReceivedBattleCardList { get; }
    }
}
