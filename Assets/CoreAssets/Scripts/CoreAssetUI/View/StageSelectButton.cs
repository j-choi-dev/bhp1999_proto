using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class StageSelectButton : MonoBehaviour
    {
        [SerializeField] private ObservableButton _stageButton = null;
        [SerializeField] private ObservableLabel _stageLabel = null;

        [SerializeField] private GameObject _flameMark = null;
        [SerializeField] private GameObject _cursorMark = null;
        [SerializeField] private GameObject _isAvaliableMark = null;
        [SerializeField] private ObservableToggle _isClearToggle = null;

        private string _id = string.Empty;
        public string ID => _id;

        public IObservable<Unit> OnClick => _stageButton.OnClick;

        public void SetStageID( string id ) => _id = id;
        public void SetButtonEnabled( bool isEnabled ) => _stageButton.Enable = isEnabled;
        public void SetStageLabel( string value ) => _stageLabel.SetValueWithoutNotify( value );
        public void SetFlameMarkActive( bool isVal ) => _flameMark.SetActive( isVal );
        public void SetCursorActive( bool isVal ) => _cursorMark.SetActive( isVal );
        public void SetAvaliableState( bool isVal ) => _isAvaliableMark.SetActive( isVal );
        public void SetClearedState( bool isAvaliable ) => _isClearToggle.SetValueWithoutNotify( isAvaliable );
    }
}
