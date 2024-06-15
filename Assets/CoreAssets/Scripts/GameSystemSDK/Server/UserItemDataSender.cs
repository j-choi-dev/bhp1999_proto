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

        public async UniTask SendUserCardDataRequest()
        {
            await UniTask.Delay( 100 );
            Debug.LogError($"{new System.NotImplementedException( "SendUserCardDataRequest" ).Message}");
        }
    }
}
