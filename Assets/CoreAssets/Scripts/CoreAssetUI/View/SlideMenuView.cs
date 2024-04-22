using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace CoreAssetUI.View
{
    public class SlideMenuView : MonoBehaviour
    {
        [SerializeField] private ObservableButton _onButton;
        [SerializeField] private GameObject _onModeObject;
        [SerializeField] private ObservableButton _offButton;
        [SerializeField] private GameObject _offModeObject;

        private void Awake()
        {
            OffMode();

            _onButton.OnClick
                .Subscribe(_ => OnMode() )
                .AddTo( this );

            _offButton.OnClick
                .Subscribe(_ => OffMode() )
                .AddTo( this );
        }

        private void OnMode()
        {
            _offModeObject.SetActive( false );
            _onModeObject.SetActive( true );
        }

        private void OffMode()
        {
            _onModeObject.SetActive( false );
            _offModeObject.SetActive( true );
        }
    }
}
