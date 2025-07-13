using CoreAssetUI.Presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class ResultModal : MonoBehaviour, IResultModal
    {
        [SerializeField] private ObservableButton _onConfirm = null;
        public IObservable<Unit> OnConfirm => _onConfirm.OnClick;

        public void SetActive( bool isActive )
        {
            gameObject.SetActive( isActive );
        }
    }
}
