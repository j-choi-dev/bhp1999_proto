using System;
using UniRx;

namespace GameSystemSDK.BattleScene.Application
{
    public interface IGameRuleValueCntext
    {
        IObservable<int> OnHandChanged { get; }
        IObservable<int> OnDiscardChanged { get; }
        IObservable<int> OnGoldChanged { get; }
        IObservable<int> OnCircleValueChanged { get; }
        IObservable<int> OnManaValueChanged { get; }
        IObservable<Unit> OnHandOver { get; }

        bool IsDiscardOver { get; }

        int CurrHandCount { get; }
        int MaxHandCount { get; }
        int CurrDiscardCount { get; }
        int CurrGold { get; }

        int CircleValue { get; }
        int ManaValue { get; }

        void DiscountHandCount( int val = 1 );
        void DiscountDiscardCount( int val );
        void SetMaxHandCount( int val );
        void SetMaxDiscardCount( int val );
        void SetGold( int val );

        void SetCircleValue( int value );
        void SetManaValue( int value );
    }
}
