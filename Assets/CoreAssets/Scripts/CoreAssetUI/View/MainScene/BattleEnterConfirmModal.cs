using CoreAssetUI.Presenter;
using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class BattleEnterConfirmModal : MonoBehaviour, IBattleEnterConfirmModal
    {
        [SerializeField] private ObservableButton _playButton = null;
        [SerializeField] private ObservableButton _skipButton = null;
        [SerializeField] private ObservableButton _closeButton = null;

        [SerializeField] private ObservableLabel _playLabel = null;
        [SerializeField] private ObservableLabel _discardLabel = null;

        [SerializeField] private ObservableLabel _scoreLabel = null;
        [SerializeField] private ObservableLabel _goldLabel = null;

        public IObservable<Unit> OnPlayClick => _playButton.OnClick;

        public IObservable<Unit> OnSkipClick => _skipButton.OnClick;

        public IObservable<Unit> OnCloseClick => _closeButton.OnClick;

        private void Awake()
        {
            _closeButton.OnClick
                .Subscribe( _ => gameObject.SetActive( false ) )
                .AddTo( this );
        }

        public void SetActive( bool isVal )
            => gameObject.SetActive( isVal );

        public void SetDiscardCount( string val )
            => _discardLabel.SetValueWithoutNotify( val );

        public void SetGoalScore( string val )
            => _scoreLabel.SetValueWithoutNotify( val );

        public void SetGold( string val )
            => _goldLabel.SetValueWithoutNotify( val );

        public void SetPlayCount( string val )
            => _playLabel.SetValueWithoutNotify( val );
    }
}
