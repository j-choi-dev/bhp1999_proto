using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    /// <summary>
    /// @Auth Choi 
    /// Stage 진행에 필요한 데이터 취득
    /// </summary>
    public interface IBattleInfoContext
    {
        /// <summary>
        /// 스테이지 정보 데이터 리스트
        /// </summary>
        IReadOnlyList<IStageInfoData> StageInfoList { get; }
        IReadOnlyList<IHandInfoData> HandInfoDataList { get; }
        IReadOnlyDictionary<int, IHandConditionData> HandConditionDictionary { get; }

        /// <summary>
        /// 스테이지 정보 데이터 리스트를 로드
        /// </summary>
        /// <returns>스테이지 정보 데이터 리스트</returns>
        /// <param name="rawData">Raw Text Data</param>
        UniTask<IResult<IReadOnlyList<IStageInfoData>>> LoadStageInfo( string rawData );

        /// <summary>
        /// Find Stage Info By Index
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>Stage Info Data</returns>
        IStageInfoData GetStageInfo( int index );

        /// <summary>
        /// Find Stage Info By ID(string)
        /// </summary>
        /// <param name="id">ID(string)</param>
        /// <returns>Stage Info Data</returns>
        IStageInfoData GetStageInfo( string id );

        /// <summary>
        /// 족보 데이터 리스트 처리와 관련하여 초기화를 진행
        /// </summary>
        /// <param name="rawData">족보 테이블 ID</param>
        /// <returns>None</returns>
        UniTask InitHandDataList( string rawData );

        /// <summary>
        /// 족보 조건 리스트 처리와 관련하여 초기화를 진행
        /// </summary>
        /// <param name="rawData">족보 조건 테이블 Raw Data</param>
        /// <returns>None</returns>
        UniTask InitHandConditionDataList( string rawData );
    }
}
