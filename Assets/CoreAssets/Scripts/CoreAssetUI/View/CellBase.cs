using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CoreAssetUI.View
{
    public abstract class CellBase : MonoBehaviour, ICellBase
    {
        [SerializeField] protected ObservableButtonTMPro _button;
        [SerializeField] protected GameObject _selectionMark;
        [SerializeField] protected ObservableLabel _label;
        [SerializeField] protected Image _image = null;

        public GameObject GameObject => gameObject;
        public string ID { get; set; }
        public string DisplayText { get => _label.Text; set => _label.Text = value; }
        public int Index { get; set; }

        public IObservable<Unit> OnClick => _button.OnClick;

        public bool IsVisible { get => gameObject.activeSelf; set => gameObject.SetActive( value ); }

        public abstract bool IsSelected { get; set; }

        protected bool _isInteractable;
        public bool IsInteractable
        {
            get { return _isInteractable; }
            set { _isInteractable = value; }
        }

        public void SetImage( Sprite sprite )
        {
            if( _image == false )
            {
                return;
            }
            _image.sprite = sprite;
        }

        public void SetDisplayText( string value )
        {
            DisplayText = value;
        }

        public void SetID( string value )
        {
            ID = value;
        }

        public void SetIndex( int value )
        {
            Index = value;
        }

        public void SetSelectWithoutNotify( bool isSelected )
        {
            _selectionMark.SetActive( isSelected );
            IsSelected = isSelected;
        }

        public void SetInteractable( bool isInteractable )
        {
            _button.Interactable = isInteractable;
        }
    }
}
