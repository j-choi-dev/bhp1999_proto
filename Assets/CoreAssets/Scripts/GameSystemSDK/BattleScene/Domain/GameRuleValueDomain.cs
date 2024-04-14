using System;
using UniRx;

namespace GameSystemSDK.BattleScene.Domain
{
    public class GameRuleValueDomain : IGameRuleValueDomain
    {
        private Subject<int> _onHandChanged = new Subject<int>();
        public IObservable<int> OnHandChanged => _onHandChanged;

        private Subject<int> _onDiscardChanged = new Subject<int>();
        public IObservable<int> OnDiscardChanged => _onDiscardChanged;

        private Subject<int> _onGoldChanged = new Subject<int>();
        public IObservable<int> OnGoldChanged => _onGoldChanged;

        private Subject<int> _onCircleValueChanged = new Subject<int>();
        public IObservable<int> OnCircleValueChanged => _onCircleValueChanged;

        private Subject<int> _onManaValueChanged = new Subject<int>();
        public IObservable<int> OnManaValueChanged => _onManaValueChanged;

        private Subject<Unit> _onHandOver = new Subject<Unit>();
        public IObservable<Unit> OnHandOver => _onHandOver; // TODO άτι©ͺ«ͺβ£Ώ @Choi 24.04.14

        public bool IsDiscardOver { get; private set; } = false;

        public int MaxHandCount { get; private set; } = 0;
        public int CurrHandCount { get; private set; } = 0;

        public int MaxDiscardCount { get; private set; } = 0;
        public int CurrDiscardCount { get; private set; } = 0;

        public int CurrGold { get; private set; } = 0;

        public int CircleValue { get; private set; } = 0;

        public int ManaValue { get; private set; } = 0;

        public void DiscountDiscardCount( int val )
        {
            var result = CurrDiscardCount - val ;
            CurrDiscardCount = result >= 0 ?
                result :
                0;
            _onDiscardChanged.OnNext( CurrDiscardCount );
        }

        public void DiscountHandCount( int val = 1 )
        {
            var result = CurrHandCount - val ;
            CurrHandCount = result >= 0 ?
                result :
                0;
            _onDiscardChanged.OnNext( CurrHandCount );
            if( CurrHandCount <= 0 )
            {
                _onHandOver.OnNext( Unit.Default );
            }
        }

        public void SetCircleValue( int value )
        {
            CircleValue = value;
            _onCircleValueChanged.OnNext( CircleValue );
        }

        public void SetGold( int val )
        {
            CurrGold = val;
            _onGoldChanged.OnNext( CurrGold );
        }

        public void SetManaValue( int value )
        {
            ManaValue = value;
            _onManaValueChanged.OnNext( ManaValue );
        }

        public void SetMaxHandCount( int val )
        {
            MaxHandCount = val;
            CurrHandCount = val;
            _onHandChanged.OnNext( MaxHandCount );
        }
        public void SetMaxDiscardCount( int val )
        {
            MaxDiscardCount = val;
            CurrDiscardCount = val;
            _onDiscardChanged.OnNext( MaxDiscardCount );
        }
    }
}
