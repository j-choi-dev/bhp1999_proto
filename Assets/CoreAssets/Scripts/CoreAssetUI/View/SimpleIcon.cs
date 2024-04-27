using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class SimpleIcon : CellBase
    {
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
    }
}
