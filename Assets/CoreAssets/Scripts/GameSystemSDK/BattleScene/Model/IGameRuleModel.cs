using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Cysharp.Threading.Tasks;

namespace GameSystemSDK.BattleScene.Model
{
    public interface IGameRuleModel
    {
        IObservable<int> OnHandChanged { get; }
        IObservable<int> OnDiscardChanged { get; }
        IObservable<int> OnGoldChanged { get; }
        IObservable<int> OnCircleValueChanged { get; }
        IObservable<int> OnManaValueChanged { get; }
        IObservable<Unit> OnHandOver { get; }
        IObservable<string> OnStageNameChanged { get; }
        IObservable<string> OnStageBuff1Change { get; }
        IObservable<string> OnStageBuff2Change { get; }
        IObservable<string> OnStageBuff3Change { get; }

        bool IsDiscardOver { get; }

        int CurrHandCount { get; }
        int MaxHandCount { get; }
        int CurrDiscardCount { get; }
        int CurrGold { get; }

        int CircleValue { get; }
        int ManaValue { get; }

        UniTask Initialize();

        void DiscountHandCount( int val = 1 );
        void DiscountDiscardCount( int val );
        void SetMaxHandCount( int val );
        void SetMaxDiscardCount( int val );
        void SetGold( int val );

        void SetCircleValue( int value );
        void SetManaValue( int value );
    } 
}
