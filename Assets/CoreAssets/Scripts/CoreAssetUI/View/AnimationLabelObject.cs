using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UnityEngine;
using System.Linq;

namespace CoreAssetUI.View
{
    public class AnimationLabelObject : MonoBehaviour
    {
        [SerializeField] private Animator _anim = null;
        [SerializeField] protected ObservableLabelTMPro _label;
        [SerializeField] protected ObservableLabelTMPro _labelUpper;
        private Subject<Unit> _onAnimationFinished = new Subject<Unit>();
        public IObservable<Unit> OnAnimationFinished => _onAnimationFinished;

        public GameObject GameObject => this.gameObject;

        private void Awake()
        {
            _label.gameObject.SetActive( false );
        }

        public void SetLabel( string val )
        {
            _label.Text = val;
        }

        public async UniTask Play()
        {
            _label.gameObject.SetActive( true );
            _anim.SetBool( "isPlay", true );
            await UniTask.Delay( 1000 );
            _onAnimationFinished.OnNext( Unit.Default );
            _label.gameObject.SetActive( false );
            _anim.SetBool( "isPlay", false );
        }

        public async UniTask ShowUpside()
        {
            _labelUpper.Label.color = new Color( _labelUpper.Label.color.r, _labelUpper.Label.color.g, _labelUpper.Label.color.b, 1f );
            _labelUpper.gameObject.SetActive( true );
            await UniTask.Delay( 700 );
            var alpha = _labelUpper.Label.color.a;
            while( _labelUpper.Label.color.a > 0.1f)
            {
                alpha = Mathf.Lerp( _labelUpper.Label.color.a, 0f, Time.deltaTime );
                _labelUpper.Label.color = new Color( _labelUpper.Label.color.r, _labelUpper.Label.color.g, _labelUpper.Label.color.b, alpha );
            }
            await UniTask.Delay( 1000 );
            _labelUpper.gameObject.SetActive( false );
        }

        public void ShowLabel( bool isActive )
            => _label.gameObject.SetActive( isActive );
    }
}
