using CoreAssetUI.Presenter;
using GameSystemSDK.BattleScene.Domain;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace CoreAssetUI.View
{
    public class StageSelectModal : MonoBehaviour, IStageSelectModal
    {
        [SerializeField] private ObservableLabel _worldName = null;
        [SerializeField] private ObservableLabel _stageName = null;

        [SerializeField] private List<StageSelectButton> _buttonList = null;
        [SerializeField] private List<ObservableToggle> _heartList = null;

        [SerializeField] private ObservableButton _closeButtons= null;
        [SerializeField] private ObservableButton _infoButtons= null;

        private Subject<string> _onButtonClick = new Subject<string>();
        public System.IObservable<string> OnButtonClick => _onButtonClick;

        private void Awake()
        {
            var msg = string.Empty;
            for( int i = 0; i< _buttonList.Count; i++ )
            {
                int index = i;  // 지역 변수로 현재 인덱스를 캡처
                _buttonList[index].OnClick
                    .Subscribe( _ =>
                    {
                        _onButtonClick.OnNext( _buttonList[index].ID );
                    } )
                    .AddTo( this );
            }
        }

        public void SetWorldName( string value ) 
            => _worldName.SetValueWithoutNotify( value );

        public void SetAreaName( string value ) 
            => _stageName.SetValueWithoutNotify( value );

        public void SetGuage( int value )
        {
            for(int i = 0; i< _heartList.Count; i++ )
            {
                _heartList[i].SetValueWithoutNotify( i < value );
            }
        }

        public void SetStageInfoList(IReadOnlyList<IStageInfoData> list)
        {
            var isNewArea = list.ToList().Any( arg => arg.IsClear ) == false;
            var latestClearIndex = list.ToList().FindLastIndex(arg => arg.IsClear) >= 0 ?
                list.ToList().FindLastIndex( arg => arg.IsClear ) :
                int.MinValue;

            for(int i = 0; i< _buttonList.Count; i++ )
            {
                _buttonList[i].SetStageID( list[i].ID );
                _buttonList[i].SetAvaliableState( isNewArea && i == 0 ? true : i == latestClearIndex+1);
                _buttonList[i].SetCursorActive( isNewArea && i == 0 ? true : i == latestClearIndex+1 );
                //_buttonList[i].SetButtonEnabled( i >= latestClearIndex ||
                //    latestClearIndex == list.Count-1 ); //TODO 판정오류 있음(報告済み) @Choi 
                _buttonList[i].SetButtonEnabled( isNewArea && i == 0 ? true : i <= latestClearIndex+1 );

                _buttonList[i].SetFlameMarkActive( isNewArea && i == 0 ? true : list[i].IsBossStage );
                _buttonList[i].SetClearedState( isNewArea && i == 0 ? true : list[i].IsClear );
                _buttonList[i].SetStageLabel( list[i].StageID );
            }
        }
    }
}
