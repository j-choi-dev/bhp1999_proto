using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public abstract class ObservablePercentageLabel : MonoBehaviour
    {
        public abstract string NumeratorText { get; }
        public abstract string DenominatorText { get; }
        public abstract string PercentageText { get; }
        public bool Interactable { get; set; }
        public IObservable<Unit> OnValueChanged { get; private set; }

        public abstract void SetDenominatorWithoutNotify( int value );
        public abstract void SetNumeratorWithoutNotify( int value );
        protected abstract void UpdatePercentageWithoutNotify();
    }
}
