using GameSystemSDK.BattleScene.Domain;
using System;
using System.Collections.Generic;

namespace CoreAssetUI.Presenter
{
    /// <summary>
    /// Stage Select Modal과 관련된 Interface
    /// @Auth Choi
    /// </summary>
    public interface IStageSelectModal
    {
        /// <summary>
        /// 스테이지 선택 버튼 클릭
        /// </summary>
        IObservable<string> OnButtonClick { get; }
        /// <summary>
        /// 월드 이름 지정
        /// </summary>
        /// <param name="value">월드 이름</param>
        void SetWorldName( string value );
        /// <summary>
        /// 지역 이름 지정
        /// </summary>
        /// <param name="value">지역 이름</param>
        void SetAreaName( string value );
        /// <summary>
        /// 게이지 세팅
        /// </summary>
        /// <param name="value"></param>
        void SetGuage( int value );
        /// <summary>
        /// 스테이지 정보 리스트를 지정
        /// </summary>
        /// <param name="list">스테이지 데이터를 파싱한 데이터 리스트</param>
        void SetStageInfoList( IReadOnlyList<IStageInfoData> list );
    }
}
