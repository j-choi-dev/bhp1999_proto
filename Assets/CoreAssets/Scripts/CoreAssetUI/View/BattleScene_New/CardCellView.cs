using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CoreAssetUI.View
{
    public class CardCellView : MonoBehaviour, ICellBase
    {
        [SerializeField] private ObservableButton _button = null;
        [SerializeField] private GameObject _selection = null;
        [SerializeField] private Image _image = null;
        [SerializeField] private List<Image> _scores = null;

        private Subject<string> _onSelected = new Subject<string>();

        public IObservable<string> OnSelected => _onSelected;
        public string ID { get; set; }
        public int Index { get; set; }

        public GameObject GameObject => gameObject;

        public bool IsVisiable { get; set; }
        public bool IsSelected { get; set; }
        public bool IsInteractable { get; set; }

        public IObservable<Unit> OnClick => _button.OnClick;

        public string DisplayText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void Awake()
        {
            _button.OnClick
                .Subscribe( _ => _onSelected.OnNext( ID ) )
                .AddTo( this );
        }

        private void Start()
        {
            _selection.SetActive( false );
        }

        public void SetSelectionShow( bool isOn )
            => _selection.SetActive( isOn );

        public void SetBackgroundImage( Sprite sprite )
            => _image.sprite = sprite;

        public void SetID( string id )
            => ID = id;

        public void SetActive( bool isOn )
            => gameObject.SetActive( isOn );

        public void SetDisplayText( string value )
            => throw new NotImplementedException();

        public void SetValueText( IReadOnlyList<Sprite> values )
        {
            for(int i = 0; i < _scores.Count; i++)
            {
                _scores[i].sprite = values[i]; 
            }
        }

        public void SetIndex( int value )
            => Index = value;

        public void SetSelectWithoutNotify( bool isSelected )
        {
            _selection.SetActive( isSelected );
            IsSelected = isSelected;
        }

        public void SetInteractable( bool isInteractable )
            => _button.Interactable = isInteractable;
    }
}
