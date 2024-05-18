using CoreAssetUI.Presenter;
using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class BattleInfoView : MonoBehaviour, IBattleInfoView
    {
        [SerializeField] private ObservableLabelTMPro _hand;
        [SerializeField] private ObservableLabelTMPro _discard;
        [SerializeField] private ObservableLabelTMPro _gold;

        [SerializeField] private ObservableLabelTMPro _circle;
        [SerializeField] private ObservableLabelTMPro _mana;
        [SerializeField] private ObservablePercentageLabelTMPro _deckCount;
        [SerializeField] private ObservableLabelTMPro _scorePlate;
        [SerializeField] private ObservableGuageValue _scoreGuage;

        public bool IsScorePlateOn => _scorePlate.gameObject.activeSelf;

        public void SetCircleWithoutNotify( int value ) 
            => _circle.SetValueWithoutNotify( value.ToString() );

        public void SetDeckCountWithoutNotify( int numerator, int denominator )
        {
            _deckCount.SetNumeratorWithoutNotify( numerator );
            _deckCount.SetDenominatorWithoutNotify( denominator );
        }

        public void SetDiscardCountWithoutNotify( int value ) 
            => _discard.SetValueWithoutNotify( value.ToString() );

        public void SetGoldWithoutNotify( int value ) 
            => _gold.SetValueWithoutNotify( value.ToString() );

        public void SetHandCountWithoutNotify( int value ) 
            => _hand.SetValueWithoutNotify( value.ToString() );

        public void SetManaWithoutNotify( int value ) 
            => _mana.SetValueWithoutNotify( value.ToString() );

        public void SetScorePlateOn( bool isOn )
        {
            _scorePlate.gameObject.SetActive( isOn );
        }

        public void SetScorePlateWithoutNotify( string value )
            => _scorePlate.SetValueWithoutNotify( value.ToString() );

        public void SetScorePercentageWithoutNotify( int value )
            => _scoreGuage.SetNumeratorWithoutNotify( value );

        public void SetGoalScoreWithoutNotify( int value )
            => _scoreGuage.SetDenominatorWithoutNotify( value );
    }
}
