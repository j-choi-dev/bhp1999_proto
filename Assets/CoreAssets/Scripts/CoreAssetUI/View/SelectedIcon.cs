using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class SelectedIcon : CellBase, IDoubleTapCell
    {
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
    }
}
