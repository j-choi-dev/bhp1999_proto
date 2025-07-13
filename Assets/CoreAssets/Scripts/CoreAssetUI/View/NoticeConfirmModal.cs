using CoreAssetUI.Presenter;
using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class NoticeConfirmModal : MonoBehaviour, INoticeConfirmModal
    {
        [SerializeField] protected ObservableLabel _headerTitle = null;
        [SerializeField] protected ObservableLabel _bodyTitle = null;
        [SerializeField] protected ObservableLabel _buttonMessage = null;
        [SerializeField] protected ObservableButton _confirmButton = null;

        public IObservable<Unit> OnConfirmClick => _confirmButton.OnClick;

        private void Awake()
        {
            _confirmButton.OnClick
                .Subscribe( _ => Show( false ) )
                .AddTo( this );
        }

        public void SetConfirmButtonWithoutNotify( string val )
        {
            _buttonMessage.Text = val;
        }

        public void SetHeaderTitleWithoutNotify(string val)
        {
            _headerTitle.Text = val;
        }

        public void SetMessageWithoutNotify( string val )
        {
            _bodyTitle.Text = val;
        }

        public void Show(bool isShow)
        {
            this.gameObject.SetActive( isShow );
        }
    }
}
