using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CoreAssetUI.View
{
    public interface ICellBase
    {
        int Index { get; set; }
        string ID { get; set; }
        string DisplayText { get; set; }
        void SetImage( Sprite sprite );

        IObservable<CellStateArg> OnPressed { get; }
        IObservable<CellStateArg> OnSelectionChanged { get; }
        IObservable<CellStateArg> OnHoveredChanged { get; }

        bool IsVisible { get; set; }
        bool IsHovered { get; set; }
        bool IsSelected { get; set; }

        void SetHoveredWithoutNotify( bool isHovered );
        void SetSelectWithoutNotify( bool isSelected );

        bool IsInteractable { get; set; }
    }

    public abstract class CellBase : MonoBehaviour, ICellBase
    {
        [SerializeField] private ObservableLabel _label;
        [SerializeField] private Image _image = null;

        public string ID { get; set; }
        public string DisplayText { get => _label.Text; set => _label.Text = value; }
        public int Index { get; set; }

        private Subject<CellStateArg> m_OnPressed = new Subject<CellStateArg>();
        private Subject<CellStateArg> m_OnSelectionChanged = new Subject<CellStateArg>();
        private Subject<CellStateArg> m_OnHoveredChanged = new Subject<CellStateArg>();

        public IObservable<CellStateArg> OnPressed => m_OnPressed;
        public IObservable<CellStateArg> OnSelectionChanged => m_OnSelectionChanged;
        public IObservable<CellStateArg> OnHoveredChanged => m_OnHoveredChanged;

        public bool IsVisible { get => gameObject.activeSelf; set => gameObject.SetActive( value ); }

        private bool m_IsHovered = false;
        public bool IsHovered
        {
            get => m_IsHovered;
            set
            {
                if( m_IsHovered == value )
                {
                    return;
                }
                m_IsHovered = value;
                m_OnHoveredChanged.OnNext( new CellStateArg( Index, ID, value ) );
            }
        }

        private bool m_IsSelected = false;
        public bool IsSelected
        {
            get => m_IsSelected;
            set
            {
                if( m_IsSelected == value )
                {
                    return;
                }
                m_IsSelected = value;
                m_OnSelectionChanged.OnNext( new CellStateArg( Index, ID, value ) );
            }
        }

        private bool m_IsPressed = false;
        public bool IsPressed
        {
            get => m_IsPressed;
            set
            {
                if( m_IsPressed != value )
                {
                    m_IsPressed = value;
                    if( value == false )
                    {
                        return;
                    }
                    m_OnPressed.OnNext( new CellStateArg( Index, ID, true ) );
                }
            }
        }

        private bool m_IsInteractable;
        public bool IsInteractable
        {
            get { return m_IsInteractable; }
            set { m_IsInteractable = value; }
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

        public void SetHoveredWithoutNotify( bool isHovered )
        {
            m_IsHovered = isHovered;
        }

        public void SetSelectWithoutNotify( bool isSelected )
        {
            m_IsSelected = isSelected;
        }
    }
}
