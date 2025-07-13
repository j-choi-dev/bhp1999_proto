using System.Collections.Generic;

namespace GameSystemSDK.BattleScene.Domain
{
    /// <summary>
    /// 플레잉 카드에 관련된 데이터를 저장하고 관리
    /// @Auth Samdong
    /// </summary>
    public interface IPlayingCardListStorageDomain
    {
        /// <summary>
        /// 외부에서 참조할 덱 리스트 맵퍼
        /// </summary>
        IReadOnlyList<IPlayingCardInfo> PlayingCardDeckList { get; }


        /// <summary>
        /// 플레잉 카드를 읽고 셋팅
        /// </summary>
        void InitPlayingCardList(IReadOnlyList<Dictionary<string, string>> rawData);
    }
}