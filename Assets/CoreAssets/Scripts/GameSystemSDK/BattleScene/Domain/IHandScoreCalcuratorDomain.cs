using System;
using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// Poker 점수 계산 스크립트
    /// </summary>
    /// @Auth Samdong
    public interface IHandScoreCalcuratorDomain
    {
        public IObservable<IDetailScoreInfo> OnDetailScoreInfo { get; }

        /// <summary>
        /// Get Max Score
        /// </summary>
        /// <param name="cardList">최대 5장 까지의 선택 카드 리스트</param>
        /// <returns></returns>
        /// <remarks>이걸로 점수 찾아줍니다. to 재연님</remarks>
        (int id, IReadOnlyList<IBattleCard>) GetMaxPokerScore( IReadOnlyList<IHandInfoData> handDataList,
            IReadOnlyList<IBattleCard> cardList );

        /// <summary>
        /// 족보(핸드) 연산에 필요한 데이터 탐색
        /// </summary>
        /// <param name="handDataList">족보 데이터 리스트</param>
        /// <param name="id">족보 조건 ID</param>
        /// <returns>족보 연산 데이터</returns>
        IHandConditionInfo GetPokerHandsInfoByID( IReadOnlyList<IHandInfoData> handDataList, int id );


        /// <summary>
        /// 최종 스코어와 상세 정보를 반환
        /// </summary>
        /// <param name="cardList">현재 턴에서 선택된 카드 리스트</param>
        /// <param name="condition">족보 연산 조건 데이터</param>
        /// <returns>최종 스코어와 상세 정보</returns>
        IDetailScoreInfo GetScoreData( IReadOnlyList<IBattleCard> cardList, IHandConditionInfo condition );
    }
}
