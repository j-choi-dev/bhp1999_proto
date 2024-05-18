using CoreAssetUI.Presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class ShopModal : MonoBehaviour, IShopModal
    {
        [SerializeField] private ObservableButton _onGoToNextStage = null;
        public IObservable<Unit> OnGoToNextStage => _onGoToNextStage.OnClick;

        public void SetActive( bool isActive )
        {
            gameObject.SetActive( isActive );
        }
    }
}
