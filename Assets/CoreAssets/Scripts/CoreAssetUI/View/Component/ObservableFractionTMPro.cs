using UnityEngine;
using TMPro;
using UniRx;

namespace CoreAssetUI.View
{
    public class ObservableFractionLabelTMPro : ObservableFractionLabel
    {
		[SerializeField] private TMP_Text _numerator = null;
		[SerializeField] private TMP_Text _denominator = null;

        private Subject<Unit> _onValueChange = new Subject<Unit>();

        public override string NumeratorText => _numerator.text;

        public override string DenominatorText => _denominator.text;

        public override void SetDenominatorWithoutNotify( int value )
        {
            _denominator.text = value.ToString();
            _onValueChange.OnNext( Unit.Default );
        }

        public override void SetNumeratorWithoutNotify( int value )
        {
            _numerator.text = value.ToString();
            _onValueChange.OnNext( Unit.Default );
        }
    }
}
