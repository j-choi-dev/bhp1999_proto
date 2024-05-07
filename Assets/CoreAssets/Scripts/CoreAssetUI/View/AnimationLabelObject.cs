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

        public void ShowLabel( bool isActive )
            => _label.gameObject.SetActive( isActive );
    }
}
