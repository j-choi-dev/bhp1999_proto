using System;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public interface ICellBase
    {
        GameObject GameObject { get; }

        int Index { get; set; }
        string ID { get; set; }
        string DisplayText { get; set; }

        bool IsVisible { get; set; }
        bool IsSelected { get; set; }
        bool IsInteractable { get; set; }
        IObservable<Unit> OnClick { get; }

        void SetDisplayText( string value );
        void SetID( string value );
        void SetIndex( int value );
        void SetImage( Sprite sprite );
        void SetSelectWithoutNotify( bool isSelected );
        void SetInteractable( bool isInteractable );
    }
}
