using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class BattleCardCell : CellBase, IBattleCardCell
    {
        [SerializeField] private Animator _anim = null;
        private Subject<Unit> _onDoubleSelected = new Subject<Unit>();
        public IObservable<Unit> OnDoubleSelected => _onDoubleSelected;

        private bool _isSelected = false;
        public override bool IsSelected
        {
            get => _isSelected;
            set
            {
                if( _isSelected == value )
                {
                    return;
                }
                _selectionMark.SetActive( value );
                _isSelected = value;
            }
        }

        private bool _isDoubleSelected = false;
        public bool IsDoubleSelected
        {
            get => _isDoubleSelected;
            set
            {
                if( _isDoubleSelected == value )
                {
                    return;
                }
                _selectionMark.SetActive( false );
                _isDoubleSelected = value;
                _onDoubleSelected.OnNext( Unit.Default );
            }
        }

        public void SetDoubleSelectWithoutNotify( bool isSelected )
        {
            _isDoubleSelected = IsSelected;
        }

        public async UniTask PlayCardAnimation()
        {
            _anim.SetBool( "isPlay", true );
            await UniTask.WaitUntil( () => _anim.GetCurrentAnimatorStateInfo( 0 ).normalizedTime < 1.0f );
            _anim.SetBool( "isPlay", false );
        }
    }
}
