using System;
using UniRx;

namespace GameSystemSDK.BattleScene.Domain
{
    public interface IGameRuleValueDomain
    {
        IObservable<int> OnHandChanged { get; }
        IObservable<int> OnDiscardChanged { get; }
        IObservable<int> OnGoldChanged { get; }
        IObservable<int> OnCircleValueChanged { get; }
        IObservable<int> OnManaValueChanged { get; }
        IObservable<Unit> OnHandOver { get; }
        IObservable<int> OnGoalScoreChanged { get; }

        bool IsDiscardOver { get; }

        int CurrentHandCount { get; }
        int MaxHandCount { get; }
        int CurrentDiscardCount { get; }
        int CurrGold { get; }
        int GoalScore { get; }

        int CircleValue { get; }
        int ManaValue { get; }

        void DiscountHandCount( int val = 1 );
        void DiscountDiscardCount( int val );
        void SetMaxHandCount( int val );
        void SetMaxDiscardCount( int val );
        void SetGold( int val );
        void SetGoalScore( int val );

        void SetCircleValue( int value );
        void SetManaValue( int value );
    }
}
