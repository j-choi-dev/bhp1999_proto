using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public abstract class ObservableFractionLabel : MonoBehaviour
    {
        public abstract string NumeratorText { get; }
        public abstract string DenominatorText { get; }
        public bool Interactable { get; set; }
        public IObservable<float> OnPercentageChanged { get; private set; }

        public abstract void SetDenominatorWithoutNotify( int value );
        public abstract void SetNumeratorWithoutNotify( int value );
    }
}
