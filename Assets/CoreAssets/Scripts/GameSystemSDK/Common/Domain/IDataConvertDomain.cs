using GameSystemSDK.BattleScene.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemSDK.Common.Domain
{
    /// <summary>
    /// CSV 데이터를 필요로하는 각각의 데이터형으로 파싱을 수행하는 Domain 클래스
    /// @Auth Choi
    /// </summary>
    public interface IDataConvertDomain
    {
        /// <summary>
        /// Raw 문자열을 StageInfoData형 리스트로 변환
        /// </summary>
        /// <param name="value">raw 문자열</param>
        /// <returns>StageInfoData형 리스트</returns>
        IReadOnlyList<IStageInfoData> ConverToStageInfoDataList( string value );
    }
}
