using CoreAssetUI.Presenter;
using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class TitleSceneView : MonoBehaviour, ITitleSceneView
    {
        [SerializeField] private ObservableButton _onClickLogIn = null;
        [SerializeField] private ObservableLabel _versionInfo = null;
        [SerializeField] private ObservableLabel _guidInfo = null;

        public IObservable<Unit> OnClickLogIn => _onClickLogIn.OnClick;

        private void Awake()
        {
            _onClickLogIn.OnClick
                .Subscribe( _ => _onClickLogIn.Interactable = false )
                .AddTo( this );
        }

        public void SetVersionInfo( string value )
        {
            _versionInfo.SetValueWithoutNotify( $"ver : {value}" );
        }

        public void SetGUIDInfo( string value )
        {
            _guidInfo.SetValueWithoutNotify( $"User ID : {value}" );
        }
    }
}
