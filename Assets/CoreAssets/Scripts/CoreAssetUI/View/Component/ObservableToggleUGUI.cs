using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

namespace CoreAssetUI.View
{
    public class ObservableToggleUGUI : ObservableToggle
    {
        [SerializeField] private Toggle _toggle = null;
        [SerializeField] private Image _indeterminateImage = null;

        public override bool IsActive
        {
            get => _toggle.isOn;
            set
            {
                SetIndeterminate( false );
                _toggle.isOn = value;
            }
        }

        public override IObservable<bool> OnActiveChanged => _toggle.onValueChanged.AsObservable();
        public override bool Interactable { get => _toggle.interactable; set => _toggle.interactable = value; }

        private void Awake()
        {
            _toggle.onValueChanged.AsObservable()
                .Subscribe( _ => SetIndeterminate( false ) )
                .AddTo( this );

            SetIndeterminate( false );
        }

        public override void SetIsActiveWithoutNotify( bool isActive )
        {
            SetIndeterminate( false );
            _toggle.SetIsOnWithoutNotify( isActive );
        }

        private void SetIndeterminate( bool indeterminate )
        {
            if( _indeterminateImage )
            {
                _indeterminateImage.enabled = indeterminate;
            }
        }

        public override void SetIndeterminateValue()
        {
            SetIndeterminate( true );
        }
    }
}
