using CoreAssetUI.Presenter;
using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class MainSceneFooterMenuView : MonoBehaviour, IMainSceneFooterMenuView
    {
        [SerializeField] private ObservableButton _enterToGameButton = null;

        public IObservable<Unit> OnClickEnterToGame => _enterToGameButton.OnClick;

        // Start is called before the first frame update
        private void Start()
        {
            _enterToGameButton.OnClick
                .Subscribe( arg => Debug.Log( "OnClickEnterToGame" ) )
                .AddTo( this );
        }
    }
}
