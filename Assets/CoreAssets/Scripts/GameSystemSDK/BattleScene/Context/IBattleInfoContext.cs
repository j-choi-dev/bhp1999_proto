using Cysharp.Threading.Tasks;
using GameSystemSDK.BattleScene.Domain;
using GameSystemSDK.Common.Domain;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Application
{
    /// <summary>
    /// Battle 정보 세팅을 위한 Model과 Domain을 연결
    /// @Auth Choi
    /// </summary>
    public interface IBattleInfoContext
    {
        /// <summary>
        /// 스테이지 정보 데이터 리스트
        /// </summary>
        IReadOnlyList<IStageInfoData> StageInfoList { get; }
        /// <summary>
        /// 스테이지 별 최대 턴수를 지정한 데이터 리스트
        /// </summary>
        IReadOnlyList<IHandInfoData> HandInfoDataList { get; }
        /// <summary>
        /// 덱의 족보 정보를 취득하기 위한 Dictinary
        /// </summary>
        IReadOnlyDictionary<int, IHandConditionData> HandConditionDictionary { get; }

        /// <summary>
        /// 일반 카드 정보 리스트
        /// </summary>
        IReadOnlyList<IPlayingCardInfo> PlayingCardInfoList { get; }

        /// <summary>
        /// 카드 업그레이드 리스트
        /// </summary>
        IReadOnlyList<ICardUpgradeInfo> CardUpgradeList { get; }
        /// <summary>
        /// 카드 이펙트 Dictinary
        /// </summary>
        IReadOnlyDictionary<int, ICardEffectInfo> CardEffectDictionary { get; }

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
        void InitHandDataList( string rawData );

        /// <summary>
        /// 족보 조건 리스트 처리와 관련하여 초기화를 진행
        /// </summary>
        /// <param name="rawData">족보 조건 테이블 Raw Data</param>
        void InitHandConditionDataList( string rawData );

        /// <summary>
        /// 플레잉 카드 리스트 취득
        /// </summary>
        /// <param name="rawData">플레잉 카드 테이블</param>
        void InitPlayingCardListStorageDomain( string rawData );

        /// <summary>
        /// 카드 업그레이드 관련 정보 취득
        /// </summary>
        /// <param name="rawData"></param>
        void InitCardUpgradeStorageDomain(string rawData);
        /// <summary>
        /// 족보에 의한 카드 효과 정보 취득
        /// </summary>
        /// <param name="rawData"></param>
        void InitCardEffectStorageDomain(string rawData);

        /// <summary>
        /// 플레잉 카드 덱 정보 리스트
        /// </summary>
        /// <param name="DeckGroup">deck 그룹 ID</param>
        /// <returns>플레잉 카드 정보 리스트</returns>
        // TODO 리팩터링 시 int 대신에 string Deck Group ID로 하는게 좋을 듯 @Choi
        IReadOnlyList<IPlayingCardInfo> GetPlayingCardDeck( int DeckGroup );
    }
}
