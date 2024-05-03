using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using CoreAssetUI.Presenter;

namespace CoreAssetUI.View
{

    public class RunControlView : MonoBehaviour, IRunControlView
    {
        [SerializeField] ObservableButton _playHand = null;
        [SerializeField] ObservableButton _discard = null;

        public IObservable<Unit> OnHandPlayButton => _playHand.OnClick;

        public IObservable<Unit> OnDiscardButton => _discard.OnClick;

        private void Awake()
        {
            _discard.Interactable = false;
            _playHand.Interactable = false;
        }

        public void SetDiscardInteractable( bool isValue )
        {
            _discard.Interactable = isValue;
        }

        public void SetHandPlayInteractable( bool isValue )
        {
            _playHand.Interactable = isValue;
        }
    }
}
