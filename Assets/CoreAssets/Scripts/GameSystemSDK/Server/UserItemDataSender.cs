using Cysharp.Threading.Tasks;
using GameSystemSDK.Server.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Server.Infrastructure
{
    public class UserItemDataSender : IUserItemDataSenderDomain
    {
        public UniTask SendSetUserCardDataRequest( byte[] datas )
        {
            throw new System.NotImplementedException();
        }

        public UniTask SendUserCardDataRequest()
        {
            throw new System.NotImplementedException();
        }
    }
}
