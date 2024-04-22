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
        [SerializeField] private ObservableButtonTMPro _button;
        [SerializeField] private GameObject _selectionMark;
        [SerializeField] private ObservableLabel _label;
        [SerializeField] private Image _image = null;

        public GameObject GameObject => gameObject;
        public string ID { get; set; }
        public string DisplayText { get => _label.Text; set => _label.Text = value; }
        public int Index { get; set; }

        public IObservable<Unit> OnClick => _button.OnClick;

        public bool IsVisible { get => gameObject.activeSelf; set => gameObject.SetActive( value ); }

        private bool _isSelected = false;
        public bool IsSelected
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

        private bool _isInteractable;
        public bool IsInteractable
        {
            get { return _isInteractable; }
            set { _isInteractable = value; }
        }

        public void SetImage( Sprite sprite )
        {
            if( _image == false)
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
            _isSelected = isSelected;
        }
    }
}
