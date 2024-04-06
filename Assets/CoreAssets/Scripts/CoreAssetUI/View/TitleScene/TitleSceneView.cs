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

        public IObservable<Unit> OnClickLogIn => _onClickLogIn.OnClick;

        private void Awake()
        {
            _versionInfo.SetValueWithoutNotify( $"ver : proto_0.0.1" ); // TODO マジックナンバーなのでどこかで直す @Choi 24.04.06
        }

        public void SetVersionInfo( string value )
        {
            _versionInfo.SetValueWithoutNotify( value );
        }
    }
}
