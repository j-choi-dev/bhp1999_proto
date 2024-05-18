using GameSystemSDK.BattleScene.Domain;
using System;
using UniRx;

namespace GameSystemSDK.BattleScene.Application
{
    public class GameRuleValueCntext : IGameRuleValueCntext
    {
        private IGameRuleValueDomain _gameRuleValueDomain;

        public GameRuleValueCntext( IGameRuleValueDomain gameRuleValueDomain)
        {
            _gameRuleValueDomain = gameRuleValueDomain;
        }

        public IObservable<int> OnHandChanged => _gameRuleValueDomain.OnHandChanged;
        public IObservable<int> OnDiscardChanged => _gameRuleValueDomain.OnDiscardChanged;
        public IObservable<int> OnGoldChanged => _gameRuleValueDomain.OnGoldChanged;
        public IObservable<int> OnGoalScoreChanged => _gameRuleValueDomain.OnGoalScoreChanged;
        public IObservable<int> OnCircleValueChanged => _gameRuleValueDomain.OnCircleValueChanged;
        public IObservable<int> OnManaValueChanged => _gameRuleValueDomain.OnManaValueChanged;
        public IObservable<Unit> OnHandOver => _gameRuleValueDomain.OnHandOver; // TODO άτι©ͺ«ͺβ£Ώ @Choi 24.04.14

        public bool IsDiscardOver => _gameRuleValueDomain.IsDiscardOver;

        public int CurrentHandCount => _gameRuleValueDomain.CurrentHandCount;

        public int MaxHandCount => _gameRuleValueDomain.MaxHandCount;
        public int CurrentDiscardCount => _gameRuleValueDomain.CurrentDiscardCount;

        public int CurrGold => _gameRuleValueDomain.CurrGold;
        public int GoalScore => _gameRuleValueDomain.GoalScore;
        public int CircleValue => _gameRuleValueDomain.CircleValue;
        public int ManaValue => _gameRuleValueDomain.ManaValue;


        public void DiscountDiscardCount( int val ) => _gameRuleValueDomain.DiscountDiscardCount( val );
        public void DiscountHandCount( int val = 1 ) => _gameRuleValueDomain.DiscountHandCount( val );
        public void SetCircleValue( int value ) => _gameRuleValueDomain.SetCircleValue( value );

        public void SetGold( int val ) => _gameRuleValueDomain.SetGold( val );
        public void SetGoalScore( int val ) => _gameRuleValueDomain.SetGoalScore( val );

        public void SetManaValue( int value ) => _gameRuleValueDomain.SetManaValue( value );

        public void SetMaxHandCount( int val ) => _gameRuleValueDomain.SetMaxHandCount( val );
        public void SetMaxDiscardCount( int val ) => _gameRuleValueDomain.SetMaxDiscardCount( val );
    }
}
