using UnityEngine;
using TMPro;
using UniRx;

namespace CoreAssetUI.View
{
    public class ObservablePercentageLabelTMPro : ObservablePercentageLabel
    {
		[SerializeField] private TMP_Text _numerator = null;
		[SerializeField] private TMP_Text _denominator = null;
		[SerializeField] private TMP_Text _precentage = null;

        private float _percentageValue = float.MinValue;
        private Subject<float> _onPercentageChange = new Subject<float>();

        public override string NumeratorText => _numerator.text;

        public override string DenominatorText => _denominator.text;
        public override string PercentageText => _precentage.text;

        public override void SetDenominatorWithoutNotify( int value )
        {
            _denominator.text = value.ToString();
            UpdatePercentageWithoutNotify();
        }

        public override void SetNumeratorWithoutNotify( int value )
        {
            _numerator.text = value.ToString();
            UpdatePercentageWithoutNotify();
        }

        protected override void UpdatePercentageWithoutNotify()
        {
            if( _precentage == null)
            {
                return;
            }
            _percentageValue = GetPercentage();
            _precentage.text = _percentageValue.ToString( "0.00" );
            _onPercentageChange.OnNext( _percentageValue );
        }

        private float GetPercentage()
        {
            if( _denominator.text.Equals( "0" ) )
            {
                return float.NaN;
            }
            _percentageValue = Mathf.Clamp01( float.Parse( NumeratorText ) / float.Parse( DenominatorText ) );
            return float.Parse( NumeratorText ) / float.Parse( DenominatorText );
        }
    }
}
