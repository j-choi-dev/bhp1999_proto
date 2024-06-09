using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Server.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace GameSystemSDK.Server.Infrastructure
{
    public class UserItemDataReceiver : IUserItemDataReceiverDomain
    {
        private Subject<byte[]> _onReceivedBattleCardList = new Subject<byte[]>();
        public IObservable<byte[]> OnReceivedBattleCardList
            => throw new NotImplementedException();

        private CompositeDisposable _subscriptions = new CompositeDisposable();

        public UserItemDataReceiver()
        {
            Subscription().Forget();
        }

        private async UniTask Subscription()
        {
            while( true )
            {
                await UniTask.Delay( 10 );
            }
        }

        public void Dispose()
        {
            if( _subscriptions != null )
            {
                _subscriptions.Dispose();
            }
            _subscriptions = null;
        }
    }
}
