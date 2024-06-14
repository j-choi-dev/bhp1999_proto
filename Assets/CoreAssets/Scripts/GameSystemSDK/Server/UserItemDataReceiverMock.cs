using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Server.Domain;
using GameSystemSDK.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace GameSystemSDK.Server.Infrastructure
{
    public class UserItemDataReceiverMock : IUserItemDataReceiverDomain
    {
        private Subject<IReadOnlyList<ICardBase>> _onReceivedBattleCardList = new Subject<IReadOnlyList<ICardBase>>();
        public IObservable<IReadOnlyList<ICardBase>> OnReceivedBattleCardList => _onReceivedBattleCardList;

        private CompositeDisposable _subscriptions = new CompositeDisposable();

        public UserItemDataReceiverMock()
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

        public async UniTask SetMockData()
        {
            var list = new List<ICardBase>( new List<ICardBase>
            {
                new CardBase( "1101", "Diamond", "2", "2", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1102", "Diamond", "3", "3", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1103", "Diamond", "4", "4", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1104", "Diamond", "5", "5", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1105", "Diamond", "6", "6", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1106", "Diamond", "7", "7", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1107", "Diamond", "8", "8", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1108", "Diamond", "9", "9", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1109", "Diamond", "10", "10", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1110", "Diamond", "10", "11", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1111", "Diamond", "10", "12", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1112", "Diamond", "10", "13", string.Empty, string.Empty, string.Empty ),
                new CardBase( "1113", "Diamond", "10", "14", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2101", "Heart", "2", "2", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2102", "Heart", "3", "3", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2103", "Heart", "4", "4", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2104", "Heart", "5", "5", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2105", "Heart", "6", "6", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2106", "Heart", "7", "7", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2107", "Heart", "8", "8", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2108", "Heart", "9", "9", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2109", "Heart", "10", "10", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2110", "Heart", "10", "11", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2111", "Heart", "10", "12", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2112", "Heart", "10", "13", string.Empty, string.Empty, string.Empty ),
                new CardBase( "2113", "Heart", "10", "14", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3101", "Club", "2", "2", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3102", "Club", "3", "3", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3103", "Club", "4", "4", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3104", "Club", "5", "5", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3105", "Club", "6", "6", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3106", "Club", "7", "7", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3107", "Club", "8", "8", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3108", "Club", "9", "9", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3109", "Club", "10", "10", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3110", "Club", "10", "11", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3111", "Club", "10", "12", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3112", "Club", "10", "13", string.Empty, string.Empty, string.Empty ),
                new CardBase( "3113", "Club", "10", "14", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4101", "Spade", "2", "2", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4102", "Spade", "3", "3", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4103", "Spade", "4", "4", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4104", "Spade", "5", "5", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4105", "Spade", "6", "6", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4106", "Spade", "7", "7", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4107", "Spade", "8", "8", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4108", "Spade", "9", "9", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4109", "Spade", "10", "10", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4110", "Spade", "10", "11", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4111", "Spade", "10", "12", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4112", "Spade", "10", "13", string.Empty, string.Empty, string.Empty ),
                new CardBase( "4113", "Spade", "10", "14", string.Empty, string.Empty, string.Empty ) } );
            await UniTask.Delay( 10 );
            _onReceivedBattleCardList.OnNext( list );
        }
    }
}
