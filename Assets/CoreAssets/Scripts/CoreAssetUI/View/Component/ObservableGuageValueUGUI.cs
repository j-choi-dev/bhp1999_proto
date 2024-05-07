using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CoreAssetUI.View
{
    public class ObservableGuageValueUGUI : ObservableGuageValue
    {
        [SerializeField] private Slider _slider = null;
        [SerializeField] private TMP_Text _numeratorLabel = null;
        [SerializeField] private TMP_Text _denominatorLabel = null;
        [SerializeField] private TMP_Text _percentageLabel = null;

        private int _numeratorValue = 0;
        private int _denominatorValue = 0;

        private float _percentageValue = float.MinValue;
        private Subject<float> _onPercentageChange = new Subject<float>();

        public override string NumeratorText => _numeratorLabel.text;
        public override string DenominatorText => _denominatorLabel.text;
        public override string PercentageText => _percentageLabel.text;

        private void Awake()
        {
            _numeratorValue = 0;
            _denominatorValue = 1000;
            _numeratorLabel.text = $"{_numeratorValue}";
            _denominatorLabel.text = $"{_denominatorValue}";
            UpdateGuage();
        }

        public override void SetDenominatorWithoutNotify( int value )
        {
            _denominatorValue = value;
            _denominatorLabel.text = $"{_denominatorValue}";
            UpdateGuage();
            UpdatePercentage();
        }

        public override void SetNumeratorWithoutNotify( int value )
        {
            _numeratorValue = _numeratorValue += value ;
            if(_numeratorValue > _denominatorValue)
            {
                _numeratorValue = _denominatorValue;
            }
            _numeratorLabel.text = $"{_numeratorValue}";
            UpdateGuage();
            UpdatePercentage();
        }

        protected override void UpdatePercentage()
        {
            if( _percentageLabel == null )
            {
                return;
            }
            _percentageValue = GetPercentage();
            _percentageLabel.text = _percentageValue.ToString( "#.##" );
            _onPercentageChange.OnNext( _percentageValue );
        }

        private float GetPercentage()
        {
            if( _denominatorValue.Equals( "0" ) )
            {
                return float.NaN;
            }
            _percentageValue = Mathf.Clamp01( _numeratorValue / (float)_denominatorValue );
            return _percentageValue * 100f;
        }

        private void UpdateGuage()
        {
            _slider.value = _numeratorValue / ( float )_denominatorValue;
        }
    }
}
