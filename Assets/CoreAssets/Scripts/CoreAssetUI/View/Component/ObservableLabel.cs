using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public abstract class ObservableLabel : MonoBehaviour
    {
        public abstract string Text { get; set; }
        public bool Interactable { get; set; }
        public string Value { get => Text; set => Text = value; }

        public IObservable<string> OnValueChanged { get; } = Observable.Never<string>();

        public void SetIndeterminateValue()
        {
            Text = "---";
        }

        public void SetValueWithoutNotify( string value )
        {
            Text = value;
        }
    }
}
